using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapper.Context.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("efdp_product");
            builder.HasIndex(_ => _.Name);

            builder.Property(_ => _.Name).HasColumnName("name").HasMaxLength(150);
            builder.Property(_ => _.Description).HasColumnName("description");
            builder.Property(_ => _.Price).HasColumnName("price");
            builder.Property(_ => _.OldPrice).HasColumnName("old_price");
            builder.Property(_ => _.Brand).HasColumnName("brand");
            builder.Property(_ => _.CustomerId).HasColumnName("customer_id");
            builder.Property(_ => _.ProductPageId).HasColumnName("product_page_id");
            builder.Property(_ => _.Brand).HasColumnName("brand").HasMaxLength(30);
        }
    }
}
