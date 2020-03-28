using System.Data.Entity;
using System.Diagnostics;

namespace EntityFrameworkVsCoreDapper.EntityFramework
{
    public class Ef6Context : DbContext
    {
        public Ef6Context() : base("CamparationEntityDapper")
        {
            Database.Log = (query) => Debug.Write(query);

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
