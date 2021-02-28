using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Context.MapsEf6
{
    public static class AddressMapEf6
    {
        public static void MapAddress(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("efdp_address");
            modelBuilder.Entity<Address>().Property(_ => _.Number).HasColumnName("number").HasMaxLength(40);
            modelBuilder.Entity<Address>().Property(_ => _.City).HasColumnName("city").HasMaxLength(80);
            modelBuilder.Entity<Address>().Property(_ => _.Street).HasColumnName("street").HasMaxLength(150);
            modelBuilder.Entity<Address>().Property(_ => _.Country).HasColumnName("country").HasMaxLength(80);
            modelBuilder.Entity<Address>().Property(_ => _.ZipCode).HasColumnName("zip_code").HasMaxLength(30);
            modelBuilder.Entity<Address>().Property(_ => _.AdministrativeRegion).HasColumnName("administrative_region").HasMaxLength(5);
        }
    }
}
