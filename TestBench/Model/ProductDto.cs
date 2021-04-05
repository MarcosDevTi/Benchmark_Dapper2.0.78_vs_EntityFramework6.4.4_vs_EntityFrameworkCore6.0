using System;

namespace TestBench.Models
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ProductPageId { get; set; }
        public string Brand { get; set; }

    }
}
