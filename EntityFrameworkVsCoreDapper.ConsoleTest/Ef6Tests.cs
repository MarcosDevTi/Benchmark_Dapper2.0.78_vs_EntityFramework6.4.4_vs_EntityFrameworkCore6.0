using Bogus;
using EntityFrameworkVsCoreDapper.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class Ef6Tests: IEf6Tests
    {
        public void InsertAvg(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                
                using (var context = new Ef6Context())
                {
                    new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => context.Customers.Add(_));
                    context.SaveChanges();
                }

                stopwatch.Stop();
                tempo += stopwatch.Elapsed;
            }

            var result = string.Format("Temps écoulé avec EF 6: {0}", tempo / 10);
            Console.WriteLine(result);
        }

        public void AddCustomersSingles(int interactions)
        {
            var result = "";

            var faker = new Faker();
            var context = new Ef6Context();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersSingles(interactions).ForEach(_ => context.Customers.Add(_));

            context.SaveChanges();
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EF 6: {0}", stopwatch.Elapsed);
            context.Dispose();
            Console.WriteLine(result);
        }
        public void AjouterCustomersAleatoires(int interactions)
        {
            var result = "";

            var faker = new Faker();
            var context = new Ef6Context();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => context.Customers.Add(_));

            context.SaveChanges();
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EF 6: {0}", stopwatch.Elapsed);
            context.Dispose();
            Console.WriteLine(result);
        }

        public void AjouterCustomersAleatoiresOpenClose(int interactions)
        {
            var result = "";

            var faker = new Faker();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach(var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                using (var context = new Ef6Context())
                {
                    context.Customers.Add(item);

                    context.SaveChanges();
                    context.Dispose();
                }
            }
          
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EF 6: {0}", stopwatch.Elapsed);

            Console.WriteLine(result);
        }

        public void SelectCustomers(int take)
        {            
            var context = new Ef6Context();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var teste = context.Customers
                .Include(_ => _.Address)
                 .Include(_ => _.Products)
                 .Where(_ => _.Address.City.StartsWith("North") && _.Products.Any(_ => _.Brand == "Intelligent"))
                .Take(take).ToList();
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EF 6: {0}", stopwatch.Elapsed);
            context.Dispose();
            Console.WriteLine(result);
        }
    }
}
