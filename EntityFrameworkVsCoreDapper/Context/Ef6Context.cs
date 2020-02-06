using System.Data.Entity;

namespace EntityFrameworkVsCoreDapper.EntityFramework
{
    public class Ef6Context : DbContext
    {
        public Ef6Context() : base("DefaultConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
