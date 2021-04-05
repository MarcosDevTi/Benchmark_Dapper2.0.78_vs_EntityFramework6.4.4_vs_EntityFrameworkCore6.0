using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using EntityFrameworkCoreVsDapperVsAdoBenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EntityFrameworkCoreVsDapperVsAdoBenchmarkDotNet
{
    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class DapperSengleSelect
    {
        private bool firstCall;

        [Benchmark]
        public IReadOnlyList<ProductDto> GetProducts()
        {
            //var connectionStrings = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=CamparationEntityDapper; Integrated Security=True";
            //var connection = new SqlConnection(connectionStrings);
            //var sql = @"select top (50)
            //            id ProductId, name, description, price, old_price OldPrice, brand, customer_id CustomerId, product_page_id ProductPageId 
            //            from efdp_product";

            //var products = connection.Query<ProductDto>(sql);

            //return products.ToList();

            if (firstCall == false)
            {
                firstCall = true;
                Console.WriteLine("// First call");
                Thread.Sleep(1000);
            }
            else
                Thread.Sleep(10);

            return null;
        }
    }
}
