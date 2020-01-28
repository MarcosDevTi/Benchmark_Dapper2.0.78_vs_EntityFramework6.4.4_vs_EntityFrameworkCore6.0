using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class EfCoreTests : IEfCoreTests
    {
        private DotNetCoreContext _netcoreContext;
        private readonly ConsoleHelper _consoleHelper;
        public EfCoreTests(DotNetCoreContext netcoreContext, ConsoleHelper consoleHelper)
        {
            _netcoreContext = netcoreContext;
            _consoleHelper = consoleHelper;
        }

        public void InitInterface()
        {
            _netcoreContext.Products.Take(100000).ToList();
        }
        public TimeSpan InsertAvg(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                var watch = _consoleHelper.StartChrono();

                new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.Customers.Add(_));
                _netcoreContext.SaveChanges();

                watch.Watch.Stop();
                tempo += watch.Watch.Elapsed;
            }

            return _consoleHelper.DisplayChrono(tempo / 10, "EFCore");
        }
        public TimeSpan InsertAvgAsNoTracking(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                var watch = _consoleHelper.StartChrono();

                _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.Customers.Add(_));
                _netcoreContext.SaveChanges();

                watch.Watch.Stop();
                tempo += watch.Watch.Elapsed;
            }

            return _consoleHelper.DisplayChrono(tempo / 10, "EFCore");
        }
        public TimeSpan AddCustomersSingles(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersSingles(interactions).ForEach(_ => _netcoreContext.Add(_));
            _netcoreContext.SaveChanges();

            return _consoleHelper.StopChrono(watch, "EFCore").Tempo;
        }
        public TimeSpan AddCustomersSinglesAsNoTracking(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            new ListTests().ObtenirListCustomersSingles(interactions).ForEach(_ => _netcoreContext.Add(_));
            _netcoreContext.SaveChanges();

            return _consoleHelper.StopChrono(watch, "EFCore").Tempo;
        }
        public TimeSpan AjouterCustomersAleatoires(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.AddAsync(_));
            _netcoreContext.SaveChanges();

            return _consoleHelper.StopChrono(watch, "EFCore").Tempo;
        }
        public TimeSpan AjouterCustomersAleatoiresOpenClose(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            foreach (var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                _netcoreContext.Add(item);
                _netcoreContext.SaveChanges();
            }

            return _consoleHelper.StopChrono(watch, "EFCore").Tempo;
        }
        public TimeSpan AjouterCustomersAleatoiresAsNoTracking(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _netcoreContext.Add(_));
            _netcoreContext.SaveChanges();

            return _consoleHelper.StopChrono(watch, "EFCore AsNoTracking").Tempo;
        }
        public TimeSpan AjouterCustomersAleatoiresAsNoTrackingOpenClose(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            foreach (var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                _netcoreContext.Add(item);
                _netcoreContext.SaveChanges();
            }

            return _consoleHelper.StopChrono(watch, "EFCore AsNoTracking").Tempo;
        }
        public TimeSpan SelectProductsSingles(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Products.Take(take).ToList();

            return _consoleHelper.StopChrono(watch, "EF Core single select").Tempo;
        }
        public TimeSpan SelectProductsSinglesAsNoTracking(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Products.Take(take).ToList();

            return _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking").Tempo;
        }
        public TimeSpan SelectProductsSinglesAsNoTrackingHardSql(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Products.FromSqlRaw($"select top({take}) * from products").ToList();

            return _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking").Tempo;
        }
        public TimeSpan SelectCustomers(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Customers
                .Include(_ => _.Address)
                .Include(_ => _.Products)
                .Take(take).ToList();

            return _consoleHelper.StopChrono(watch, "EF Core").Tempo;
        }
        public TimeSpan SelectCustomersAsNoTracking(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Customers
              .Include(_ => _.Address)
              .Include(_ => _.Products)
              .Where(_ => _.Address.City.StartsWith("North") && _.Products.Any(_ => _.Brand == "Intelligent"))
              .Take(take)
              .ToList();

            return _consoleHelper.StopChrono(watch, "EF Core AsNoTracking").Tempo;
        }
    }
}
