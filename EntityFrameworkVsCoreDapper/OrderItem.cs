using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
