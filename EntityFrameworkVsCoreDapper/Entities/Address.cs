using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace EntityFrameworkVsCoreDapper
{
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
