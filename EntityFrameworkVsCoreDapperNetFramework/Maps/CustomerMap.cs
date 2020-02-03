using EntityFrameworkVsCoreDapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapperNetFramework.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(_ => _.AddressId);
            builder.HasIndex(_ => _.Email);
            builder.HasIndex(_ => _.Id);

            builder.Property(_ => _.FirstName).HasMaxLength(50);
            builder.Property(_ => _.LastName).HasMaxLength(80);
            builder.Property(_ => _.Email).HasMaxLength(150);
            builder.Property(_ => _.Status).HasMaxLength(20);
        }
    }
}
