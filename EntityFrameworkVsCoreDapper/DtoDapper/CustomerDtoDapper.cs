using System;
using System.Collections.Generic;

namespace EntityFrameworkVsCoreDapper.DtoDapper
{
    public class CustomerDtoDapper
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDtoDapper Address { get; set; }
        public ICollection<ProductDtoDapper> Products { get; set; } = new List<ProductDtoDapper>();
    }
}
