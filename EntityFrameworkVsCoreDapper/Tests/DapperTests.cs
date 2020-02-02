using Dapper;
using Dapper.Contrib.Extensions;
using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class DapperTests : IDapperTests
    {
        private readonly DapperContext _dapperContext;
        private readonly ConsoleHelper _consoleHelper;
        private readonly ResultService _resultService;
        public DapperTests(DapperContext dapperContext, ConsoleHelper consoleHelper, ResultService resultService)
        {
            _dapperContext = dapperContext;
            _consoleHelper = consoleHelper;
            _resultService = resultService;
        }

        public TimeSpan SelectProductsSingles(int take)
        {
            var sql = $"select top({take}) * from products";

            var watch = _consoleHelper.StartChrono();

            var rders = _dapperContext.OpenedConnection.Query<Product>(sql);

            var result = _consoleHelper.StopChrono(watch, "Dapper single select");

            _resultService.SaveSelect(take, result.Tempo, watch.InitMemory, TypeTransaction.Dapper, OperationType.SelectSingle);

            return result.Tempo;
        }
        public TimeSpan SelectCustomers(int take)
        {
            var sql = new StringBuilder()
                .AppendLine("SELECT [t].[Id], [t].[AddressId], [t].[BirthDate], [t].[Email], [t].[FirstName], [t].[LastName], [t].[Status], ")
                .AppendLine("	   [a0].[Id], [a0].[AdministrativeRegion], [a0].[City], [a0].[Country], [a0].[Number], [a0].[Street], [a0].[ZipCode], ")
                .AppendLine("	   [p0].[Id], [p0].[Brand], [p0].[CustomerId], [p0].[Description], [p0].[Name], [p0].[OldPrice], [p0].[Price]")
                .AppendLine("FROM (")
                .AppendLine($"    SELECT TOP({take}) [c].[Id], [c].[AddressId], [c].[BirthDate], [c].[Email], [c].[FirstName], [c].[LastName], [c].[Status]")
                .AppendLine("    FROM [Customers] AS [c]")
                .AppendLine("    LEFT JOIN [Address] AS [a] ON [c].[AddressId] = [a].[Id]")
                .AppendLine("    WHERE ([a].[City] IS NOT NULL AND ([a].[City] LIKE 'North%')) AND EXISTS (")
                .AppendLine("        SELECT 1")
                .AppendLine("        FROM [Products] AS [p]")
                .AppendLine("        WHERE ([c].[Id] = [p].[CustomerId]) AND ([p].[Brand] = 'Intelligent'))")
                .AppendLine(") AS [t]")
                .AppendLine("LEFT JOIN [Address] AS [a0] ON [t].[AddressId] = [a0].[Id]")
                .AppendLine("LEFT JOIN [Products] AS [p0] ON [t].[Id] = [p0].[CustomerId]")
                .ToString();

            var watch = _consoleHelper.StartChrono();

            var customerDictionary = new Dictionary<Guid, Customer>();

            var rders = _dapperContext.OpenedConnection.Query<Customer, Address, Product, Customer>(
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
                splitOn: "Id, Id").Distinct();

            var tempoResult = _consoleHelper.StopChrono(watch, "Dapper").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.Dapper, OperationType.SelectComplex);

            return tempoResult;
        }

        public TimeSpan InsertProductsSingles(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            using (var transaction = _dapperContext.OpenedConnection.BeginTransaction())
            {
                AddProducts(new ListTests().ObtenirListProductsAleatoire(interactions, null), transaction);
                transaction.Commit();
            }
            var tempoResult = _consoleHelper.StopChrono(watch, "Dapper").Tempo;

            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Dapper, OperationType.InsertSingle);
            return tempoResult;
        }

        public TimeSpan AjouterCustomersAleatoires(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            using (var transaction = _dapperContext.OpenedConnection.BeginTransaction())
            {
                AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions), transaction);
                transaction.Commit();
            }

            var tempoResult = _consoleHelper.StopChrono(watch, "Dapper").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Dapper, OperationType.InsertComplex);
            return tempoResult;
        }

        public TimeSpan InsertAvg(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                var watch = _consoleHelper.StartChrono();

                using (var transaction = _dapperContext.OpenedConnection.BeginTransaction())
                {
                    AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions), transaction);
                    transaction.Commit();
                    transaction.Dispose();
                }

                watch.Watch.Stop();
                tempo += watch.Watch.Elapsed;
            }

            return _consoleHelper.DisplayChrono(tempo / 10, "Dapper");
        }

        public TimeSpan AddCustomersSingles(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            using (var transaction = _dapperContext.OpenedConnection.BeginTransaction())
            {
                AddCustomersSingles(new ListTests().ObtenirListCustomersSingles(interactions), transaction);
                transaction.Commit();
            }

            return _consoleHelper.StopChrono(watch, "Dapper").Tempo;
        }



        public void AddCustomersSingles(IEnumerable<Customer> customers, IDbTransaction transaction)
        {
            foreach (var customer in customers)
            {
                AddCustomer(customer, transaction);
            }
        }

        public void AddCustomers(IEnumerable<Customer> customers, IDbTransaction transaction)
        {
            foreach (var customer in customers)
            {
                AddAddress(customer.Address, transaction);
                AddCustomer(customer, transaction);

                foreach (var product in customer.Products)
                {
                    AddProduct(product, transaction);
                }
            }
        }

        public void AddProducts(IEnumerable<Product> products, IDbTransaction transaction)
        {
            foreach (var product in products)
                AddProduct(product, transaction);
        }


        public void AddProduct(Product product, IDbTransaction transaction)
        {
            var sql = "INSERT INTO PRODUCTS (Id, Name, Description, Price, OldPrice, Brand, CustomerId) Values" +
                "(@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId);";
            _dapperContext.OpenedConnection.Execute(sql, product, transaction: transaction);
        }
        public void AddAddress(Address address, IDbTransaction transaction)
        {
            var sql = "Insert into Address (Id, Number, Street, City, Country, ZipCode, AdministrativeRegion) Values" +
                "(@Id, @Number, @Street, @City, @Country, @ZipCode, @AdministrativeRegion)";
            _dapperContext.OpenedConnection.Execute(sql, address, transaction: transaction);
        }
        public void AddCustomer(Customer customer, IDbTransaction transaction)
        {
            var sql = "Insert into Customers (Id, FirstName, LastName, Email, Status, BirthDate, AddressId) Values" +
                $"(@Id, @FirstName, @LastName, @Email, @Status, @BirthDate, @AddressId)";
            _dapperContext.OpenedConnection.Execute(sql, customer, transaction: transaction);
        }
        public void AddCustomerContrib(Customer customer, IDbTransaction transaction) =>
             _dapperContext.OpenedConnection.Insert(customer, transaction);
        public void AddProductContrib(Product product, IDbTransaction transaction) =>
            _dapperContext.OpenedConnection.Insert(product, transaction);
        public void AddAddressContrib(Address address, IDbTransaction transaction) =>
            _dapperContext.OpenedConnection.Insert(address, transaction);


    }
}

