using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
