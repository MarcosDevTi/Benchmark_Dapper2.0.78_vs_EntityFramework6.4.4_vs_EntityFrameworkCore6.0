using EntityFrameworkVsCoreDapper.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestBench.Models;

namespace TestBench
{
    public class EfCoreSingleSelect
    {
        private readonly DotNetCoreContext _context;
        public EfCoreSingleSelect(DotNetCoreContext context)
        {
            _context = context;
        }
        public IReadOnlyList<ProductDto> GetProductsEF(int count)
        {
            var listResult = new List<ProductDto>();
            for (var i = 0; i < count; i++)
            {
                var products = _context.Products.Select(_ => new ProductDto
                {
                    ProductId = _.Id,
                    Name = _.Name,
                    Description = _.Description,
                    Price = _.Price,
                    OldPrice = _.OldPrice,
                    Brand = _.Brand,
                    CustomerId = _.CustomerId,
                    ProductPageId = _.ProductPageId
                }).Take(i).ToList();

                listResult.AddRange(products);
            }

            Console.WriteLine($"Ef total: {listResult.Count()}");

            return listResult;
        }
    }
}
