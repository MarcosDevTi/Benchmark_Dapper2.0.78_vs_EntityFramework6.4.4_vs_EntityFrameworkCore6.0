using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class DapperTests
    {
        public void AjouterCustomersAleatoires(int interactions)
        {

            var result = "";
            string sql =
                "INSERT INTO Customers (Id, Name, Email, Street, Number, City, Country) Values (@Id, @Name, @Email, @Street, @Number, @City, @Country);";
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ =>
                         dbConnection.Execute(sql, _, transaction: transaction)
                    );
                    
                    transaction.Commit();
                }
                    
            }
            stopwatch.Stop();

            result = string.Format("Temps écoulé avec Dapper ------------: {0}", stopwatch.Elapsed);
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

            var result = string.Format("Temps écoulé avec Dapper ------------: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void Insert1Item()
        {
            string sql =
                "INSERT INTO Customers (Id, Name, Email, Street, Number, City, Country) Values (@Id, @Name, @Email, @Street, @Number, @City, @Country);";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    new ListTests().ObtenirListCustomersAleatoire(1).ForEach(_ =>
                         dbConnection.Execute(sql, _, transaction: transaction)
                    );

                    transaction.Commit();
                }
                dbConnection.Close();
            }
        }

        public void InsertTransactionPerItem(int interactions)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < interactions; i++)
            {
                Insert1Item();
            }
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec Dapper Transaction Per Item: {0}", stopwatch.Elapsed);
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
    }
}

