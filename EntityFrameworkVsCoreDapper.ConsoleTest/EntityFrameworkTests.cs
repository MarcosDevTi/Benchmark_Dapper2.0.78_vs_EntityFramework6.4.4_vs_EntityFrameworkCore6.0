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
            result = string.Format("Temps écoulé avec EFCore: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }

        public void AjouterCustomersAleatoiresOpenClose(int interactions)
        {
            var result = "";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach(var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                using (var context = new TesteContext())
                {
                    context.Add(item);
                    context.SaveChanges();
                    context.Dispose();
                }
            }

            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EFCore: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);

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
            result = string.Format("Temps écoulé avec EFCore AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }

        public void AjouterCustomersAleatoiresAsNoTrackingOpenClose(int interactions)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach(var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                using (var context = new TesteContext())
                {
                    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    context.Add(item);
                    context.SaveChanges();
                    context.Dispose();
                }
            }
            
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EFCore AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void SelectCustomers(int take)
        {
            var context = new TesteContext();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var teste = context.Customers
                .Include(_ => _.Address)
                .Include(_ => _.Orders).ThenInclude(o => o.OrderItems).ThenInclude(p => p.Product)
                .Take(take).ToList();
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EF Core: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }


        public void SelectCustomersAsNoTracking(int take)
        {
            var context = new TesteContext();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var teste = context.Customers
              .Include(_ => _.Address)
              .Include(_ => _.Orders).ThenInclude(o => o.OrderItems).ThenInclude(p => p.Product)
              .Take(take).ToList();
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EF 6 Core AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            context.Dispose();
        }
    }
}
