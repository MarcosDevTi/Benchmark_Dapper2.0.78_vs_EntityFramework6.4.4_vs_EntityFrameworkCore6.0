using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkVsCoreDapper
{
    [Table("Address")]
    public class Address
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string AdministrativeRegion { get; set; }
    }
}
