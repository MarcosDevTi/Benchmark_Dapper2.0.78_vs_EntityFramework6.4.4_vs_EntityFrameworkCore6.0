using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapper.Context.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("efdp_address");
            builder.Property(_ => _.Number).HasColumnName("number").HasMaxLength(40);
            builder.Property(_ => _.City).HasColumnName("city").HasMaxLength(80);
            builder.Property(_ => _.Street).HasColumnName("street").HasMaxLength(150);
            builder.Property(_ => _.Country).HasColumnName("country").HasMaxLength(80);
            builder.Property(_ => _.ZipCode).HasColumnName("zip_code").HasMaxLength(30);
            builder.Property(_ => _.AdministrativeRegion).HasColumnName("administrative_region").HasMaxLength(5);
        }
    }
}
