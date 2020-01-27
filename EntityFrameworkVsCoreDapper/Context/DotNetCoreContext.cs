using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.EntityFramework
{
    public class DotNetCoreContext: DbContext
    {
        public DotNetCoreContext(DbContextOptions<DotNetCoreContext> options)
            :base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; 
        //                   Initial Catalog=CamparationEntityDapper; Integrated Security=True");
        //}
    }
}
