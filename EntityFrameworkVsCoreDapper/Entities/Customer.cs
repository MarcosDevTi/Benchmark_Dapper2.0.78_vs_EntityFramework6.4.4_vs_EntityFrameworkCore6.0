using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper
{
    public class Customer: Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public Guid? AddressId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
