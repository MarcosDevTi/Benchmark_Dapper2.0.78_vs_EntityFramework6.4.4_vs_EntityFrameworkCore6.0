using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapper.Context.Maps
{
    public class ProductPageMap : IEntityTypeConfiguration<ProductPage>
    {
        public void Configure(EntityTypeBuilder<ProductPage> builder)
        {
            builder.ToTable("efdp_product_page");

            builder.Property(_ => _.Title).HasColumnName("title").HasMaxLength(50);
            builder.Property(_ => _.SmallDescription).HasColumnName("small_description").HasMaxLength(120);
            builder.Property(_ => _.FullDescription).HasColumnName("full_description").HasMaxLength(500);
            builder.Property(_ => _.ImageLink).HasColumnName("image_link").HasMaxLength(300);
        }
    }
}
