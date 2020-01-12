using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class Ef6Tests
    {
        public void AjouterCustomersAleatoires(int interactions)
        {
            var result = "";

            var faker = new Faker();
            var context = new EntityFramework.Ef6Context();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => context.Customers.Add(_));

            context.SaveChanges();
            stopwatch.Stop();
            result = string.Format("EF 6 --------------: {0}", stopwatch.Elapsed);
            context.Dispose();
            Console.WriteLine(result);
        }

        public void SelectCustomers(int take)
        {            
            var context = new EntityFramework.Ef6Context();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var teste = context.Customers.Take(take).ToList();
            stopwatch.Stop();
            var result = string.Format("EF 6 --------------: {0}", stopwatch.Elapsed);
            context.Dispose();
            Console.WriteLine(result);
        }
    }
}
