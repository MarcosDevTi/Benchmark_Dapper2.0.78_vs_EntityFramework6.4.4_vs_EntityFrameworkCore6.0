using EntityFrameworkVsCoreDapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapperNetFramework.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(_ => _.Id);
            builder.HasIndex(_ => _.Name);
            builder.Property(_ => _.Name).HasMaxLength(150);
            builder.Property(_ => _.Brand).HasMaxLength(30);
        }
    }
}
