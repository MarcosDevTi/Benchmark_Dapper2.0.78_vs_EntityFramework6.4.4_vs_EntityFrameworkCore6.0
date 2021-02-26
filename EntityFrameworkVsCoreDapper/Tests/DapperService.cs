using Bogus;
using Dapper;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Helpers;
using EntityFrameworkVsCoreDapper.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Tests
{
    public class DapperService : IDapperService
    {
        private readonly DapperContext _dapperContext;
        private readonly ConsoleHelper _consoleHelper;
        private readonly ResultService _resultService;
        public DapperService(DapperContext dapperContext, ConsoleHelper consoleHelper, ResultService resultService)
        {
            _dapperContext = dapperContext;
            _consoleHelper = consoleHelper;
            _resultService = resultService;
        }

        public async Task<TimeSpan> SelectSingleProducts(int take)
        {
            var sql = $@"select top(@take) id, name, description, price, old_price OldPrice,
                        brand, customer_id CustomerId, product_page_id ProductPageId
                        from efdp_product";

            var watch = _consoleHelper.StartChrono();

            var rders = await _dapperContext.OpenedConnection.QueryAsync<Product>(
                sql, new { take });

            var result = _consoleHelper.StopChrono(watch, "Dapper single select");

            await _resultService.SaveSelect(take, result.Tempo, watch.InitMemory, TypeTransaction.Dapper, OperationType.SelectSingle);

            return result.Tempo;
        }
        public async Task<TimeSpan> SelectComplexCustomers(int take)
        {
            var test =
                @"select 
                cust.first_name FirstName, cust.last_name LastName, cust.email Email, cust.status Status, 
                    cust.birth_date BirthDate,
                cust.address_id, addr.id, addr.number, addr.street, addr.city, addr.country, addr.zip_code ZipCode,
                    addr.administrative_region AdministrativeRegion,
                prod.id IdProduct, prod.id, prod.name, prod.description, prod.price, prod.old_price OldPrice, prod.brand,
                prod.product_page_id ProductPageId, prod_pg.Id, prod_pg.title, prod_pg.small_description SmallDescription,
                    prod_pg.full_description FullDescription, prod_pg.image_link ImageLink
                from efdp_customer cust
                left join efdp_address addr on addr.id = cust.address_id
                left join efdp_product prod on prod.customer_id = cust.id
                left join efdp_product_page prod_pg on prod_pg.Id = prod.product_page_id";
            var faker = new Faker();
            var sql = new StringBuilder()
                .AppendLine("SELECT [t].[Id], [t].[AddressId], [t].[BirthDate], [t].[Email], [t].[FirstName], [t].[LastName], [t].[Status], [a0].[Id], " +
                "[a0].[AdministrativeRegion], [a0].[City], [a0].[Country], [a0].[Number], [a0].[Street], [a0].[ZipCode], [p0].[Id], [p0].[Brand], [p0].[CustomerId], " +
                "[p0].[Description], [p0].[Name], [p0].[OldPrice], [p0].[Price]")
                .AppendLine("FROM (")
                .AppendLine($"    SELECT TOP({take}) [c].[Id], [c].[AddressId], [c].[BirthDate], [c].[Email], [c].[FirstName], [c].[LastName], [c].[Status]")
                .AppendLine("    FROM [Customers] AS [c]")
                .AppendLine("    LEFT JOIN [Addresses] AS [a] ON [c].[AddressId] = [a].[Id]")
                .AppendLine($"    WHERE ((([c].[FirstName] <> N'{faker.Name.FirstName().Replace("'", "")}') OR [c].[FirstName] IS NULL) AND ([a].[City] IS NOT NULL AND NOT ([a].[City]" +
                $" LIKE N'{faker.Address.City().Replace("'", "")}%'))) AND EXISTS (")
                .AppendLine("        SELECT 1")
                .AppendLine("        FROM [Products] AS [p]")
                .AppendLine($"        WHERE ([c].[Id] = [p].[CustomerId]) AND (([p].[Description] <> N'{faker.Commerce.ProductName().Replace("'", "")}') OR [p].[Description] IS NULL))")
                .AppendLine(") AS [t]")
                .AppendLine("LEFT JOIN [Addresses] AS [a0] ON [t].[AddressId] = [a0].[Id]")
                .AppendLine("LEFT JOIN [Products] AS [p0] ON [t].[Id] = [p0].[CustomerId]")
                .AppendLine("ORDER BY [t].[Id], [p0].[Id]")
                .ToString();

            var watch = _consoleHelper.StartChrono();

            var customerDictionary = new Dictionary<Guid, Customer>();

            var rders = await _dapperContext.OpenedConnection.QueryAsync<Customer, Address, Product, Customer>(
                sql,
                (customer, address, product) =>
                {
                    Customer customerEntry;

                    if (!customerDictionary.TryGetValue(customer.Id, out customerEntry))
                    {
                        customerEntry = customer;
                        customerEntry.Products = new List<Product>();
                        customerDictionary.Add(customerEntry.Id, customerEntry);
                    }

                    customerEntry.Products.Add(product);
                    customer.Address = address;
                    return customerEntry;
                },
                splitOn: "Id, Id");
            var tt = rders.Distinct();

            var tempoResult = _consoleHelper.StopChrono(watch, "Dapper").Tempo;
            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.Dapper, OperationType.SelectComplex);

            return tempoResult;
        }

        public async Task<TimeSpan> InsertSingleProducts(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            using (var transaction = _dapperContext.OpenedConnection.BeginTransaction())
            {
                await AddProducts(new ListTests().ObtenirListProductsAleatoire(interactions, null), transaction);
                transaction.Commit();
            }
            var tempoResult = _consoleHelper.StopChrono(watch, "Dapper").Tempo;

            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Dapper, OperationType.InsertSingle);
            return tempoResult;
        }
        public async Task<TimeSpan> InsertComplexCustomers(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            using (var transaction = _dapperContext.OpenedConnection.BeginTransaction())
            {
                await AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions), transaction);
                transaction.Commit();
            }

            var tempoResult = _consoleHelper.StopChrono(watch, "Dapper").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Dapper,
                OperationType.InsertComplex);
            return tempoResult;
        }

        public async Task AddCustomers(IEnumerable<Customer> customers, IDbTransaction transaction)
        {
            var adresses = customers.Select(c => c.Address);
            var sqlAdresses = "Insert into efdp_address (id, number, street, city, country, zip_code, administrative_region) Values" +
               "(@Id, @Number, @Street, @City, @Country, @ZipCode, @AdministrativeRegion)";
            await _dapperContext.OpenedConnection.ExecuteAsync(sqlAdresses, adresses, transaction: transaction);

            var sql = "Insert into efdp_customer (id, first_name, last_name, email, status, birth_date, address_id) Values" +
                $"(@Id, @FirstName, @LastName, @Email, @Status, @BirthDate, @AddressId)";
            await _dapperContext.OpenedConnection.ExecuteAsync(sql, customers, transaction: transaction);

            var productsPageSql =
                @"insert into efdp_product_page
                  (id, title, small_description, full_description, image_link)
                  Values (@Id, @Title, @SmallDescription, @FullDescription, @ImageLink)";
            var pages = customers.SelectMany(c => c.Products).Select(_ => _.ProductPage);
            await _dapperContext.OpenedConnection.ExecuteAsync(productsPageSql, pages, transaction: transaction);
            
            var products = customers.SelectMany(c => c.Products);
            var sqlProducts = "insert into efdp_product (id, name, description, price, old_price, brand, customer_id, product_page_id) Values" +
              "(@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId, @ProductPageId);";
            await _dapperContext.OpenedConnection.ExecuteAsync(sqlProducts, products, transaction: transaction);
        }
        public async Task AddProducts(IEnumerable<Product> products, IDbTransaction transaction)
        {
            var sql = "INSERT INTO efdp_product (id, name, description, price, old_price, brand, customer_id) Values" +
                "(@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId);";
            await _dapperContext.OpenedConnection.ExecuteAsync(sql, products, transaction: transaction);
        }
    }
}