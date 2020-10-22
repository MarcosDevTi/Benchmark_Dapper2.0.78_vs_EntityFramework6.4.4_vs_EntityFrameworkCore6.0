using EntityFrameworkVsCoreDapper.Context.Maps;
using EntityFrameworkVsCoreDapper.Entities;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkVsCoreDapper.Context
{
    public class DotNetCoreContext : DbContext
    {
        public DotNetCoreContext(DbContextOptions<DotNetCoreContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ProductPage> ProductPages { get; set; }
        public DbSet<ValueChoice> ValueChoices { get; set; }
        public DbSet<ValueDomain> ValueDomains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new ProductPageMap());
            modelBuilder.ApplyConfiguration(new ValueChoiceMap());
            modelBuilder.ApplyConfiguration(new ValueDomainMap());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
        //                   Initial Catalog=CamparationEntityDapper; Integrated Security=True");
        //}
    }
}
