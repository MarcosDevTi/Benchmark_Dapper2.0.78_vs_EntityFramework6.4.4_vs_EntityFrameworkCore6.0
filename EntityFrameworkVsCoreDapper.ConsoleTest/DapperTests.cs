using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class DapperTests
    {
        public void AjouterCustomersAleatoires(int interactions)
        {

            var result = "";
            
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


        public void AjouterCustomersAleatoiresOpenClose(int interactions)
        {

            var result = "";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();

                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        AddCustomers(new List<Customer> { item }, dbConnection, transaction);

                        transaction.Commit();
                    }
                    dbConnection.Close();
                }
            }
            
            stopwatch.Stop();

            result = string.Format("Temps écoulé avec Dapper: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void SelectCustomers(int take)
        {
            string sql = $"select top {take} * from  Customers";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                var rders = dbConnection.Query<Customer>(sql).AsList();

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

        public void AddCustomers(IEnumerable<Customer> customers, IDbConnection conn, IDbTransaction transaction)
        {
            foreach(var customer in customers)
            {
                AddAddress(customer.Address, conn, transaction);
                AddCustomer(customer, conn, transaction);

                foreach (var order in customer.Orders)
                {
                    AddOrder(order, conn, transaction);
                    foreach (var orderItem in order.OrderItems)
                    {
                        AddProduct(orderItem.Product, conn, transaction);
                        AddOrderItem(orderItem, conn, transaction);
                    }
                }
            }
        }

        public void AddProduct(Product product, IDbConnection conn, IDbTransaction transaction)
        {
            var sql = "INSERT INTO PRODUCTS (Id, Name, Description, Price, OldPrice, Brand) Values" +
                "(@Id, @Name, @Description, @Price, @OldPrice, @Brand);";
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

        public void AddOrder(Order order, IDbConnection conn, IDbTransaction transaction)
        {
            var sql = "Insert into Orders (Id, CustomerId) Values (@Id, @CustomerId)";
            conn.Execute(sql, order, transaction: transaction);
        }

        public void AddOrderItem(OrderItem orderItem, IDbConnection conn, IDbTransaction transaction)
        {
            var sql = "Insert into OrderItems (Id, ProductId, OrderId) Values (@Id, @ProductId, @OrderId)";
            conn.Execute(sql, orderItem, transaction: transaction);
        }
    }
}

