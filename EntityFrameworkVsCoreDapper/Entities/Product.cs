using EntityFrameworkVsCoreDapper.Entities;
using System;

namespace EntityFrameworkVsCoreDapper
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string Brand { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ProductPageId { get; set; }
        public ValueChoice Category { get; set; }
        public ProductPage ProductPage { get; set; }
    }
}
