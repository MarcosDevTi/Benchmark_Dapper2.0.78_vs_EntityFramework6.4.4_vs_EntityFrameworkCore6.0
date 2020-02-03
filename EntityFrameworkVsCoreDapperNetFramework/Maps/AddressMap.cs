using EntityFrameworkVsCoreDapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapperNetFramework.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasIndex(_ => _.Id);
            builder.Property(_ => _.City).HasMaxLength(80);
            builder.Property(_ => _.Street).HasMaxLength(150);
            builder.Property(_ => _.Country).HasMaxLength(80);
            builder.Property(_ => _.ZipCode).HasMaxLength(30);
            builder.Property(_ => _.AdministrativeRegion).HasMaxLength(5);
        }
    }
}
