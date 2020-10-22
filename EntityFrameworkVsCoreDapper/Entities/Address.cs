using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkVsCoreDapper
{
    [Table("Address")]
    public class Address : Entity
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string AdministrativeRegion { get; set; }

    }
}
