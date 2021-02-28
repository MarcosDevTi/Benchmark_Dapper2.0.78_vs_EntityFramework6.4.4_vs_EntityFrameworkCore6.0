using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapper.Context.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("efdp_customer");
            builder.HasIndex(_ => _.AddressId);
            builder.HasIndex(_ => _.Email);

            builder.Property(_ => _.FirstName).HasColumnName("first_name").HasMaxLength(50);
            builder.Property(_ => _.LastName).HasColumnName("last_name").HasMaxLength(80);
            builder.Property(_ => _.Email).HasColumnName("email").HasMaxLength(150);
            builder.Property(_ => _.Status).HasColumnName("status").HasMaxLength(20);
            builder.Property(_ => _.BirthDate).HasColumnName("birth_date");
            builder.Property(_ => _.AddressId).HasColumnName("address_id");
        }
    }
}
