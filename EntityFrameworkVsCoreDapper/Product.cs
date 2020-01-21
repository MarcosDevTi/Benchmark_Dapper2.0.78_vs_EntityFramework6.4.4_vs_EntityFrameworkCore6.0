using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string Brand { get; set; }
    }
}
