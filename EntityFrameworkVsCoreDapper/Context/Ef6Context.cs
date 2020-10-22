using EntityFrameworkVsCoreDapper.Entities;
using System.Data.Entity;
using System.Diagnostics;

namespace EntityFrameworkVsCoreDapper.Context
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
        public DbSet<ProductPage> ProductPages { get; set; }
        public DbSet<ValueChoice> ValueChoices { get; set; }
        public DbSet<ValueDomain> ValueDomains { get; set; }
    }
}
