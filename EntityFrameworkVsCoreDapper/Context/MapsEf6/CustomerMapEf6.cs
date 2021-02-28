using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Context.MapsEf6
{
    public static class CustomerMapEf6
    {
        public static void MapCustomerEf6(this DbModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("efdp_customer");
            builder.Entity<Customer>().HasIndex(_ => _.AddressId);
            builder.Entity<Customer>().HasIndex(_ => _.Email);
            builder.Entity<Customer>().Property(_ => _.FirstName).HasColumnName("first_name").HasMaxLength(50);
            builder.Entity<Customer>().Property(_ => _.LastName).HasColumnName("last_name").HasMaxLength(80);
            builder.Entity<Customer>().Property(_ => _.Email).HasColumnName("email").HasMaxLength(150);
            builder.Entity<Customer>().Property(_ => _.Status).HasColumnName("status").HasMaxLength(20);
            builder.Entity<Customer>().Property(_ => _.BirthDate).HasColumnName("birth_date");
            builder.Entity<Customer>().Property(_ => _.AddressId).HasColumnName("address_id");
        }
    }
}
