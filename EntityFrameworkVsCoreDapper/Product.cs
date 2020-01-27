using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Photo { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public Guid CustomerId { get; set; }
    }
}
