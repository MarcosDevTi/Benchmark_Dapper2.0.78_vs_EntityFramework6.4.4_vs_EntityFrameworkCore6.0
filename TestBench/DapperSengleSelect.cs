using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestBench.Models;

namespace TestBench
{
    public class DapperSengleSelect
    {
        private readonly IDbConnection _connection;

        public DapperSengleSelect(IDbConnection connection)
        {
            _connection = connection;
        }

        public IReadOnlyList<ProductDto> GetProducts(int count)
        {
            var sql = @$"select top (@count)
                        id ProductId, name, description, price, old_price OldPrice, brand, customer_id CustomerId, product_page_id ProductPageId 
                        from efdp_product";

            var listResult = new List<ProductDto>();
            for (var i = 0; i < count; i++)
            {
                var products = _connection.Query<ProductDto>(sql, new { count = i });
                listResult.AddRange(products.ToList());
            }

            Console.WriteLine($"Dapper total: {listResult.Count()}");
            return listResult;
        }
    }
}
