using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Context.MapsEf6
{
    public static class ProductPageMapEf6
    {
        public static void MapProductPageMap(this DbModelBuilder builder)
        {
            builder.Entity<ProductPage>().ToTable("efdp_product_page");
            builder.Entity<ProductPage>().Property(_ => _.Title).HasColumnName("title").HasMaxLength(50);
            builder.Entity<ProductPage>().Property(_ => _.SmallDescription).HasColumnName("small_description").HasMaxLength(120);
            builder.Entity<ProductPage>().Property(_ => _.FullDescription).HasColumnName("full_description").HasMaxLength(500);
            builder.Entity<ProductPage>().Property(_ => _.ImageLink).HasColumnName("image_link").HasMaxLength(300);
        }
    }
}
