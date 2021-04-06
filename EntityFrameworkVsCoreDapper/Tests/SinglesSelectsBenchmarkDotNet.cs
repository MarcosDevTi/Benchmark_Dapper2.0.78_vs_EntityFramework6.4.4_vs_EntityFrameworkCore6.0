using Dapper;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Scaffolding.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Tests
{
    public class SinglesSelectsBenchmarkDotNet
    {
        public async Task SelectSingleProductsAdo(int take, SqlConnection sqlConnection)
        {
            var sql = $@"select top(@take) id, name, description, price, old_price, brand
                        from efdp_product";

            using var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.Add(new SqlParameter("@take", take));

            if (sqlConnection.State == ConnectionState.Closed)
            {
                await sqlConnection.OpenAsync();
            }
            var listResult = new List<Product>();
            using var dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                listResult.Add(new Product
                {
                    Id = dr.GetFieldValue<Guid>("id"),
                    Name = dr.GetFieldValue<string>("name"),
                    Description = dr.GetFieldValue<string>("description"),
                    Price = dr.GetFieldValue<decimal>("price"),
                    OldPrice = dr.GetFieldValue<decimal>("old_price"),
                    Brand = dr.GetFieldValue<string>("brand")
                });
            }
        }

        public async Task SelectSingleProductsDapper(int take, SqlConnection sqlConnection)
        {
            var sql = $@"select top(@take) id, name, description, price, old_price OldPrice, brand
                        from efdp_product";

            if (sqlConnection.State == ConnectionState.Closed)
            {
                await sqlConnection.OpenAsync();
            }

            var list = await sqlConnection.QueryAsync<Product>(sql, new { take });
        }

        public async Task SelectSingleProductsEfCore(int take, DotNetCoreContext dotNetCoreContext)
        {
            var rr = await dotNetCoreContext.Products.Take(take).ToListAsync();
        }

        public async Task SelectSingleProductsEf6(int take, Ef6Context ef6Context)
        {
            var rr = await ef6Context.Products.Take(take).ToListEf6Async();
        }
    }
}
