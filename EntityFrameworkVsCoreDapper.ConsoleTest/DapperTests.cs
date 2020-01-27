using Bogus;
using Dapper;
using Dapper.Contrib.Extensions;
using EntityFrameworkVsCoreDapper.ConsoleTest.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class DapperTests: IDapperTests
    {

        public void SelectProductsSingles(int take)
        {
            var sql = $"select top({take}) * from products";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var rders = dbConnection.Query<Product>(sql);
                dbConnection.Close();
            }

            stopwatch.Stop();

            var result = string.Format("Temps écoulé avec Dapper single select: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }
        public void SelectCustomers(int take)
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

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            var customerDictionary = new Dictionary<Guid, Customer>();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                var rders = dbConnection.Query<Customer, Address, Product, Customer>(
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
            }

            stopwatch.Stop();

            var result = string.Format("Temps écoulé avec Dapper: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public IDbConnection Connection
        {
            get
            {
                var connStrings = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=CamparationEntityDapper; Integrated Security=True";
                return new SqlConnection(connStrings);
            }
        }

        public void InsertAvg(int interactions)
        {
            Connection.Open();

            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();

                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions), dbConnection, transaction);
                        transaction.Commit();
                        transaction.Dispose();
                    }
                }

                stopwatch.Stop();
                tempo += stopwatch.Elapsed;
            }
            Connection.Close();
            var result = string.Format("Temps écoulé avec Dapper: {0}", tempo / 10);
            Console.WriteLine(result);
        }

        public void AddCustomersSingles(int interactions)
        {
            var result = "";
            Connection.Open();
            var faker = new Faker();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    AddCustomersSingles(new ListTests().ObtenirListCustomersSingles(interactions), dbConnection, transaction);
                    transaction.Commit();
                }
            }

            stopwatch.Stop();
            result = string.Format("Temps écoulé avec Dapper: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);

            
        }

        public void AjouterCustomersAleatoires(int interactions)
        {
            var result = "";
            Connection.Open();
            var faker = new Faker();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    AddCustomers(new ListTests().ObtenirListCustomersAleatoire(interactions), dbConnection, transaction);
                    transaction.Commit();
                }
            }

            stopwatch.Stop();
            result = string.Format("Temps écoulé avec Dapper: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void AddCustomersSingles(IEnumerable<Customer> customers, IDbConnection conn, IDbTransaction transaction)
        {
            foreach (var customer in customers)
            {
                AddCustomer(customer, conn, transaction);
            }
        }

        public void AddCustomers(IEnumerable<Customer> customers, IDbConnection conn, IDbTransaction transaction)
        {
            foreach (var customer in customers)
            {
                AddAddress(customer.Address, conn, transaction);
                AddCustomer(customer, conn, transaction);

                foreach (var product in customer.Products)
                {
                    AddProduct(product, conn, transaction);
                }
            }
        }

        public void AddProduct(Product product, IDbConnection conn, IDbTransaction transaction)
        {
            var sql = "INSERT INTO PRODUCTS (Id, Name, Description, Price, OldPrice, Brand, CustomerId) Values" +
                "(@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId);";
            conn.Execute(sql, product, transaction: transaction);
        }
        public void AddAddress(Address address, IDbConnection conn, IDbTransaction transaction)
        {
            var sql = "Insert into Address (Id, Number, Street, City, Country, ZipCode, AdministrativeRegion) Values" +
                "(@Id, @Number, @Street, @City, @Country, @ZipCode, @AdministrativeRegion)";
            conn.Execute(sql, address, transaction: transaction);
        }
        public void AddCustomer(Customer customer, IDbConnection conn, IDbTransaction transaction)
        {
            var sql = "Insert into Customers (Id, FirstName, LastName, Email, Status, BirthDate, AddressId) Values" +
                $"(@Id, @FirstName, @LastName, @Email, @Status, @BirthDate, @AddressId)";
            conn.Execute(sql, customer, transaction: transaction);
        }
        public void AddCustomerContrib(Customer customer, IDbConnection conn, IDbTransaction transaction) =>
             conn.Insert(customer, transaction);
        public void AddProductContrib(Product product, IDbConnection conn, IDbTransaction transaction) =>
            conn.Insert(product, transaction);
        public void AddAddressContrib(Address address, IDbConnection conn, IDbTransaction transaction) =>
            conn.Insert(address, transaction);
    }
}

