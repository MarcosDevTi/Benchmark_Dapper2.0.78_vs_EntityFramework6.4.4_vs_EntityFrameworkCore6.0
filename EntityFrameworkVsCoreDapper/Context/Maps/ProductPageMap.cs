using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkVsCoreDapper.Context.Maps
{
    public class ProductPageMap : IEntityTypeConfiguration<ProductPage>
    {
        public void Configure(EntityTypeBuilder<ProductPage> builder)
        {
            builder.HasIndex(_ => _.Id);
            builder.Property(_ => _.Title).HasMaxLength(50);
            builder.Property(_ => _.SmallDescription).HasMaxLength(120);
            builder.Property(_ => _.FullDescription).HasMaxLength(500);
            builder.Property(_ => _.ImageLink).HasMaxLength(300);
        }
    }
}
