using Bogus;
using EntityFrameworkVsCoreDapper.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class EntityFrameworkTests
    {

        public void AjouterCustomersAleatoires(int interactions)
        {
            var result = "";

            var faker = new Faker();
            var context = new TesteContext();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => context.Add(_));

            context.SaveChanges();
            stopwatch.Stop();
            result = string.Format("EF Core -----------: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }

        public void AjouterCustomersAleatoiresAsNoTracking(int interactions)
        {
            var result = "";

            var faker = new Faker();
            var context = new TesteContext();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => context.Add(_));

            context.SaveChanges();
            stopwatch.Stop();
            result = string.Format("EFCore AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }

        public void Insert1Item()
        {
            var faker = new Faker();

            using (var context = new TesteContext())
            {
                new ListTests().ObtenirListCustomersAleatoire(1).ForEach(_ => context.Add(_));
                context.SaveChanges();
            }
        }

        public void InsertTransactionPerItem(int interactions)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < interactions; i++)
            {
                Insert1Item();
            }
            stopwatch.Stop();
            var result = string.Format("Ef Core Transaction Per Item: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void SelectCustomers(int take)
        {
            var context = new TesteContext();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var teste = context.Customers.Take(take).ToList();
            stopwatch.Stop();
            var result = string.Format("EF Core -----------: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }

        public void SelectCustomersAsNoTracking(int take)
        {
            var context = new TesteContext();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var teste = context.Customers.Take(take).ToList();
            stopwatch.Stop();
            var result = string.Format("EFCore AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }
    }
}
