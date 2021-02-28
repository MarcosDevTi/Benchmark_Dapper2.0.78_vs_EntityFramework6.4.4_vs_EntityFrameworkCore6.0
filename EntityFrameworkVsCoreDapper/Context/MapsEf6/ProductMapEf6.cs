using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Context.MapsEf6
{
    public static class ProductMapEf6
    {
        public static void MapProductEf6(this DbModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("efdp_product");
            builder.Entity<Product>().HasIndex(_ => _.Name);
            builder.Entity<Product>().Property(_ => _.Name).HasColumnName("name").HasMaxLength(150);
            builder.Entity<Product>().Property(_ => _.Description).HasColumnName("description");
            builder.Entity<Product>().Property(_ => _.Price).HasColumnName("price");
            builder.Entity<Product>().Property(_ => _.OldPrice).HasColumnName("old_price");
            builder.Entity<Product>().Property(_ => _.Brand).HasColumnName("brand");
            builder.Entity<Product>().Property(_ => _.CustomerId).HasColumnName("customer_id");
            builder.Entity<Product>().Property(_ => _.ProductPageId).HasColumnName("product_page_id");
            builder.Entity<Product>().Property(_ => _.Brand).HasColumnName("brand").HasMaxLength(30);
        }
    }
}
