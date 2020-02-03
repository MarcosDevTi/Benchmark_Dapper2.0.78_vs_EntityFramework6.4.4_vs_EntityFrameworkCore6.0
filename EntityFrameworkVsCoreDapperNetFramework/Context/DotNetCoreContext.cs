using EntityFrameworkVsCoreDapper;
using EntityFrameworkVsCoreDapperNetFramework.Results;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkVsCoreDapperNetFramework.Context
{
    public class DotNetCoreContext : DbContext
    {
        public DotNetCoreContext(DbContextOptions<DotNetCoreContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Result> Results { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new ProductMap());
        //    modelBuilder.ApplyConfiguration(new CustomerMap());
        //    modelBuilder.ApplyConfiguration(new AddressMap());
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
        //                   Initial Catalog=CamparationEntityDapper; Integrated Security=True");
        //}
    }
}
