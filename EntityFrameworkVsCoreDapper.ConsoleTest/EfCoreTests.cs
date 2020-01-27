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
    public class EfCoreTests: IEfCoreTests
    {
        private DotNetCoreContext _netcoreContext;
        public EfCoreTests(DotNetCoreContext netcoreContext)
        {
            _netcoreContext = netcoreContext;
        }
        public void InsertAvg(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.Customers.Add(_));
                _netcoreContext.SaveChanges();

                stopwatch.Stop();
                tempo += stopwatch.Elapsed;
            }

            var result = string.Format("Temps écoulé avec EFCore: {0}", tempo / 10);
            Console.WriteLine(result);
        }

        public void InsertAvgAsNoTracking(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.Customers.Add(_));
                _netcoreContext.SaveChanges();

                stopwatch.Stop();
                tempo += stopwatch.Elapsed;
            }

            var result = string.Format("Temps écoulé avec EFCore: {0}", tempo / 10);
            Console.WriteLine(result);
        }

        public void AddCustomersSingles(int interactions)
        {
            var result = "";

            var faker = new Faker();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersSingles(interactions).ForEach(_ => _netcoreContext.Add(_));

            _netcoreContext.SaveChanges();
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EFCore: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }


        public void AddCustomersSinglesAsNoTracking(int interactions)
        {
            var result = "";

            var faker = new Faker();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            new ListTests().ObtenirListCustomersSingles(interactions).ForEach(_ => _netcoreContext.Add(_));

            _netcoreContext.SaveChanges();
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EFCore: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void AjouterCustomersAleatoires(int interactions)
        {
            var result = "";

            var faker = new Faker();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.AddAsync(_));

            _netcoreContext.SaveChanges();
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EFCore: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void AjouterCustomersAleatoiresOpenClose(int interactions)
        {
            var result = "";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {

                _netcoreContext.Add(item);
                _netcoreContext.SaveChanges();

            }

            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EFCore: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);

        }

        public void AjouterCustomersAleatoiresAsNoTracking(int interactions)
        {
            var result = "";

            var faker = new Faker();
            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.Add(_));

            _netcoreContext.SaveChanges();
            stopwatch.Stop();
            result = string.Format("Temps écoulé avec EFCore AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void AjouterCustomersAleatoiresAsNoTrackingOpenClose(int interactions)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                _netcoreContext.Add(item);
                _netcoreContext.SaveChanges();
            }

            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EFCore AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }

        public void SelectProductsSingles(int take)
        {

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var teste = _netcoreContext.Products.Take(take).ToList();

                stopwatch.Stop();
                var result = string.Format("Temps écoulé avec EF Core single select: {0}", stopwatch.Elapsed);
                Console.WriteLine(result);
                teste = null;
        }

        public void SelectProductsSinglesAsNoTracking(int take)
        {
            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var teste = _netcoreContext.Products.Take(take).ToList();

                stopwatch.Stop();
                var result = string.Format("Temps écoulé avec EF Core single select AsNoTracking: {0}", stopwatch.Elapsed);
                Console.WriteLine(result);
                teste = null;
        }


        public void SelectProductsSinglesAsNoTrackingHardSql(int take)
        {
        _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var teste = _netcoreContext.Products.FromSqlRaw($"select top({take}) * from products").ToList();

                stopwatch.Stop();
                var result = string.Format("Temps écoulé avec EF Core single select AsNoTracking: {0}", stopwatch.Elapsed);
                Console.WriteLine(result);
                teste = null;
        }

        public void SelectCustomers(int take)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var teste = _netcoreContext.Customers
                .Include(_ => _.Address)
                .Include(_ => _.Products)
                .Take(take);

            var list = teste.ToList();
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EF Core: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
            list = null;
        }

        public void SelectCustomersAsNoTracking(int take)
        {
            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var teste = _netcoreContext.Customers
              .Include(_ => _.Address)
              .Include(_ => _.Products)
              .Where(_ => _.Address.City.StartsWith("North") && _.Products.Any(_ => _.Brand == "Intelligent"))
              .Take(take)
              .ToList();
            stopwatch.Stop();
            var result = string.Format("Temps écoulé avec EF 6 Core AsNoTracking: {0}", stopwatch.Elapsed);
            Console.WriteLine(result);
        }
    }
}
