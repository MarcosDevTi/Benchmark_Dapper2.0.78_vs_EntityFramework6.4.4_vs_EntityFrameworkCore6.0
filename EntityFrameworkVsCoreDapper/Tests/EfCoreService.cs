using Bogus;
using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Extensions;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
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

        public TimeSpan InsertComplexCustomers(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.AddAsync(_));
            _netcoreContext.SaveChanges();
            var tempoResult = _consoleHelper.StopChrono(watch, "EFCore").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.InsertComplex);
            return tempoResult;
        }
        public TimeSpan SelectSingleProducts(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Products.Take(take).ToList();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select").Tempo;

            watch.Watch.Stop();

            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.SelectSingle);

            return tempoResult;
        }
        public TimeSpan SelectSingleProductsAsNoTracking(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Products.Take(take).ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking").Tempo;

            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTracking, OperationType.SelectSingle);

            return tempoResult;
        }
        public TimeSpan SelectSingleProductsAsNoTrackingSqlQuery(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Products.FromSqlRaw($"select top({take}) * from products").ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking SqlHard").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.SelectSingle);
            return tempoResult;
        }
        public TimeSpan SelectComplexCustomers(int take)
        {
            var faker = new Faker();
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Customers.Include(_ => _.Address).Include(_ => _.Products)
                .Where(_ => _.FirstName != "Test First Name" && !_.Address.City.StartsWith(faker.Address.City().Replace("'", "")) && 
                _.Products.Count(_ => _.Description != faker.Commerce.ProductName().Replace("'", "")) > 0)
                .Take(take);

            var res = teste.ToList();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.SelectComplex);
            return tempoResult;
        }
        public TimeSpan SelectComplexCustomersAsNoTracking(int take)
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

            

            var aa = teste.ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core AsNoTracking").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTracking, OperationType.SelectComplex);
            return tempoResult;
        }
        public TimeSpan InsertSingleProducts(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListProductsAleatoire(interactions, null).ForEach(_ => _netcoreContext.Products.Add(_));
            _netcoreContext.SaveChanges();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.InsertSingle);
            return tempoResult;
        }
        public TimeSpan InsertSingleProductsAsNoTrackingSqlCommand(int interactions)
        {
            var watch = _consoleHelper.StartChrono();


            AddProducts(new ListTests().ObtenirListProductsAleatoire(interactions, null));
            _netcoreContext.SaveChanges();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.InsertSingle);
            return tempoResult;
        }
        public TimeSpan InsertComplexCustomersAsNoTrackingSqlCommand(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions));
            _netcoreContext.SaveChanges();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.InsertComplex);
            return tempoResult;
        }

        public void AddCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                AddAddress(customer.Address);
                AddCustomer(customer);

                foreach (var product in customer.Products)
                    AddProduct(product);
            }
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
                AddProduct(product);
        }

        public void AddProduct(Product product)
        {
            var sql = "INSERT INTO PRODUCTS (Id, Name, Description, Price, OldPrice, Brand, CustomerId) Values" +
                $"('{product.Id}', '{product.Name}', '{product.Description}', {product.Price.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, " +
                $"{product.OldPrice.ToString(CultureInfo.CreateSpecificCulture("en-US"))}, '{product.Brand}', {FormatCustomer(product.CustomerId)})";
            _netcoreContext.Database.ExecuteSqlCommand(sql);
        }

        private string FormatCustomer(Guid? id)
        {
            if (id == null)
                return "null";
            return $"'{id}'";
        }
        public void AddAddress(Address address)
        {
            var sql = "Insert into Address (Id, Number, Street, City, Country, ZipCode, AdministrativeRegion) Values" +
                $"('{address.Id}','{address.Number}', '{address.Street.Replace("'", "")}', '{address.City.Replace("'", "")}', '{address.Country.Replace("'", "")}', '{address.ZipCode}', '{address.AdministrativeRegion}')";
            _netcoreContext.Database.ExecuteSqlCommand(sql);
        }
        public void AddCustomer(Customer customer)
        {
            var sql = "Insert into Customers (Id, FirstName, LastName, Email, Status, BirthDate, AddressId) Values" +
                $"('{customer.Id}', '{customer.FirstName.Replace("'", "")}', '{customer.LastName.Replace("'", "")}', '{customer.Email}', '{customer.Status}', '{customer.BirthDate}', '{customer.AddressId}')";
            _netcoreContext.Database.ExecuteSqlCommand(sql);
        }
    }
}
