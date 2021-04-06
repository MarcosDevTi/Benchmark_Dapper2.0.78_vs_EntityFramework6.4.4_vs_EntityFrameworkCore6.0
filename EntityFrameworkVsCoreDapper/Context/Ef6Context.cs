using EntityFrameworkVsCoreDapper.Context.MapsEf6;
using System.Data.Entity;
using System.Diagnostics;

namespace EntityFrameworkVsCoreDapper.Context
{
    public class Ef6Context : DbContext
    {
        public Ef6Context() : base("CamparationEntityDapper")
        {
            Database.Log = (query) => Debug.Write(query);
            Database.SetInitializer<Ef6Context>(null);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ProductPage> ProductPages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.MapAddress();
            modelBuilder.MapCustomerEf6();
            modelBuilder.MapProductEf6();
            modelBuilder.MapProductPageMap();

            // base.OnModelCreating(modelBuilder);
        }
    }
}
