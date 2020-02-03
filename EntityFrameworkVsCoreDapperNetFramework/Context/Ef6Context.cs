using EntityFrameworkVsCoreDapper;
using System.Data.Entity;

namespace EntityFrameworkVsCoreDapperNetFramework.Context
{
    public class Ef6Context : DbContext
    {
        public Ef6Context() : base("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = CamparationEntityDapper; Integrated Security = True")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
