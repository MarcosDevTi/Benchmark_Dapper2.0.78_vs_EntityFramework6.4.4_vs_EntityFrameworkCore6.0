using Bogus;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Helpers;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Tests
{
    public class EfCoreService : IEfCoreService
    {
        private readonly DotNetCoreContext _netcoreContext;
        private readonly ConsoleHelper _consoleHelper;
        private readonly ResultService _resultService;
        public EfCoreService(DotNetCoreContext netcoreContext, ConsoleHelper consoleHelper, ResultService resultService)
        {
            _netcoreContext = netcoreContext;
            _consoleHelper = consoleHelper;
            _resultService = resultService;
        }

        public async Task<TimeSpan> InsertComplexCustomers(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersAleatoire(interactions)
                .ForEach(async _ => await _netcoreContext.AddAsync(_));
            await _netcoreContext.SaveChangesAsync();
            var tempoResult = _consoleHelper.StopChrono(watch, "EFCore").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.InsertComplex);
            return tempoResult;
        }
        public async Task<TimeSpan> SelectSingleProducts(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Products.Take(take).ToList();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select").Tempo;

            watch.Watch.Stop();

            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.SelectSingle);

            return tempoResult;
        }
        public async Task<TimeSpan> SelectSingleProductsAsNoTracking(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = await _netcoreContext.Products.Take(take).ToListAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking").Tempo;

            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTracking, OperationType.SelectSingle);

            return tempoResult;
        }
        public async Task<TimeSpan> SelectSingleProductsAsNoTrackingSqlQuery(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = await _netcoreContext.Products.FromSqlRaw(
                $"select top({take}) * from products").ToListAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking SqlHard").Tempo;
            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.SelectSingle);
            return tempoResult;
        }
        public async Task<TimeSpan> SelectComplexCustomers(int take)
        {
            var faker = new Faker();
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Customers.Include(_ => _.Address).Include(_ => _.Products)
                .Where(_ => _.FirstName != "Test First Name" && !_.Address.City.StartsWith(faker.Address.City().Replace("'", "")) &&
                _.Products.Count(_ => _.Description != faker.Commerce.ProductName().Replace("'", "")) > 0)
                .Take(take);

            var res = await teste.ToListAsync();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.SelectComplex);
            return tempoResult;
        }
        public async Task<TimeSpan> SelectComplexCustomersAsNoTracking(int take)
        {
            var faker = new Faker();
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Customers
                .Include(_ => _.Address)
                .Include(_ => _.Products)
                .Where(_ => _.FirstName != "Test First Name" && !_.Address.City.StartsWith(faker.Address.City().Replace("'", "")) && _.Products.Any(_ =>
                _.Description != faker.Commerce.ProductName().Replace("'", "")))
                .Take(take);



            var aa = await teste.ToListAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core AsNoTracking").Tempo;
            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTracking, OperationType.SelectComplex);
            return tempoResult;
        }
        public async Task<TimeSpan> InsertSingleProducts(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListProductsAleatoire(interactions, null).ForEach(async _ => await _netcoreContext.Products.AddAsync(_));
            await _netcoreContext.SaveChangesAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.InsertSingle);
            return tempoResult;
        }
        public async Task<TimeSpan> InsertSingleProductsAsNoTrackingSqlCommand(int interactions)
        {
            var watch = _consoleHelper.StartChrono();


            await AddProducts(new ListTests().ObtenirListProductsAleatoire(interactions, null));
            await _netcoreContext.SaveChangesAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.InsertSingle);
            return tempoResult;
        }
        public async Task<TimeSpan> InsertComplexCustomersAsNoTrackingSqlCommand(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            await AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions));
            await _netcoreContext.SaveChangesAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.InsertComplex);
            return tempoResult;
        }

        public async Task AddCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                await AddAddress(customer.Address);
                await AddCustomer(customer);

                foreach (var product in customer.Products)
                    await AddProduct(product);
            }
        }

        public async Task AddProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
                await AddProduct(product);
        }

        public async Task AddProduct(Product product)
        {
            var sql = "INSERT INTO PRODUCTS (Id, Name, Description, Price, OldPrice, Brand, CustomerId) Values" +
                $"('{product.Id}', '{product.Name}', '{product.Description}', {product.Price.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, " +
                $"{product.OldPrice.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, '{product.Brand}', {FormatCustomer(product.CustomerId)})";
            await _netcoreContext.Database.ExecuteSqlRawAsync(sql);
        }

        private string FormatCustomer(Guid? id)
        {
            return id == null ? "null" : $"'{id}'";
        }
        public async Task AddAddress(Address address)
        {
            var sql = "Insert into Address (Id, Number, Street, City, Country, ZipCode, AdministrativeRegion) Values" +
                $"('{address.Id}','{address.Number}', '{address.Street.Replace("'", "")}', '{address.City.Replace("'", "")}', '{address.Country.Replace("'", "")}', '{address.ZipCode}', '{address.AdministrativeRegion}')";
            await _netcoreContext.Database.ExecuteSqlRawAsync(sql);
        }
        public async Task AddCustomer(Customer customer)
        {
            var sql = "Insert into Customers (Id, FirstName, LastName, Email, Status, BirthDate, AddressId) Values" +
                $"('{customer.Id}', '{customer.FirstName.Replace("'", "")}', '{customer.LastName.Replace("'", "")}', '{customer.Email}', '{customer.Status}', '{customer.BirthDate}', '{customer.AddressId}')";
            await _netcoreContext.Database.ExecuteSqlRawAsync(sql);
        }
    }
}
