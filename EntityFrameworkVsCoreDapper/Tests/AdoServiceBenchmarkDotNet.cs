using Dapper;
using EntityFrameworkVsCoreDapper.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Tests
{
    public class AdoServiceBenchmarkDotNet
    {
        public async Task InsertSingleProductsSqlBulkCopy(int interactions, SqlConnection sqlConnection)
        {
            await AddProductsAdoSqlBulkCopy(new ListTests().ObtenirListProductsAleatoire(interactions, null), sqlConnection);
        }

        public async Task InsertSingleProductsAdo(int interactions, string connectionStrings)
        {
            await AddProductsAdo(new ListTests().ObtenirListProductsAleatoire(interactions, null), connectionStrings);
        }

        public async Task InsertSingleProductsDapper(int interactions, SqlConnection sqlConnection)
        {
            await AddProductsDapper(new ListTests().ObtenirListProductsAleatoire(interactions, null), sqlConnection);
        }

        public async Task InsertSingleProductsEfCore(int interactions, DotNetCoreContext dotNetCoreContext)
        {
            var listCustomers = new ListTests().ObtenirListProductsAleatoire(interactions, null);

            await dotNetCoreContext.Products.AddRangeAsync(listCustomers);
            await dotNetCoreContext.SaveChangesAsync();
        }

        private async Task AddProductsAdoSqlBulkCopy(IEnumerable<Product> products, SqlConnection sqlConnection)
        {
            using var sqlBulkCopy = new SqlBulkCopy(sqlConnection);
            sqlBulkCopy.DestinationTableName = "efdp_product";
            sqlConnection.Open();
            await sqlBulkCopy.WriteToServerAsync(BuildProductDateTable(products));
            sqlConnection.Close();
        }

        private async Task AddProductsAdo(IEnumerable<Product> products, string connectionString)
        {
            var sql = @"insert into efdp_product (id, name, description, price, old_price, brand) Values ";

            var listParams = new List<string>();

            for (var i = 0; i < products.Count(); i++)
                listParams.Add($"(@Id{i}, @Name{i}, @Description{i}, @Price{i}, @OldPrice{i}, @Brand{i})");

            sql += string.Join(",\r\n", listParams.ToArray());

            using var conn = new SqlConnection(connectionString);

            using var cmd = new SqlCommand(sql, conn);

            for (var i = 0; i < products.Count(); i++)
            {
                var product = products.ToArray()[i];

                cmd.Parameters.Add(new SqlParameter($"@Id{i}", product.Id));
                cmd.Parameters.Add(new SqlParameter($"@Name{i}", product.Name));
                cmd.Parameters.Add(new SqlParameter($"@Description{i}", product.Description));
                cmd.Parameters.Add(new SqlParameter($"@Price{i}", product.Price));
                cmd.Parameters.Add(new SqlParameter($"@OldPrice{i}", product.OldPrice));
                cmd.Parameters.Add(new SqlParameter($"@Brand{i}", product.Brand));
            }

            cmd.CommandType = CommandType.Text;

            if (conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync();
            }

            await cmd.ExecuteNonQueryAsync();
        }

        private async Task AddProductsDapper(IEnumerable<Product> products, IDbConnection dbConnection)
        {
            var sql = @"insert into efdp_product (id, name, description, price, old_price, brand, customer_id) Values
                        (@Id, @Name, @Description, @Price, @OldPrice, @Brand, @CustomerId);";

            await dbConnection.ExecuteAsync(sql, products);
        }

        private DataTable BuildProductDateTable(IEnumerable<Product> products)
        {
            var dt = new DataTable();
            dt.Columns.Add("id", typeof(Guid));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("old_price", typeof(decimal));
            dt.Columns.Add("brand", typeof(string));


            foreach (var product in products)
                dt.Rows.Add(
                    product.Id, product.Name, product.Description, product.Price, product.OldPrice,
                    product.Brand);

            dt.AcceptChanges();

            return dt;
        }
    }
}
