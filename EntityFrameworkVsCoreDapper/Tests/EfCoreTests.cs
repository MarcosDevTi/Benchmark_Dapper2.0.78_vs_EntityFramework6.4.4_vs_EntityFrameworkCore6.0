using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class EfCoreTests : IEfCoreTests
    {
        private readonly DotNetCoreContext _netcoreContext;
        private readonly ConsoleHelper _consoleHelper;
        private readonly ResultService _resultService;
        public EfCoreTests(DotNetCoreContext netcoreContext, ConsoleHelper consoleHelper, ResultService resultService)
        {
            _netcoreContext = netcoreContext;
            _consoleHelper = consoleHelper;
            _resultService = resultService;
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
            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select").Tempo;

            watch.Watch.Stop();

            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.SelectSingle);

            return tempoResult;
        }

        public TimeSpan SelectProductsSinglesAsNoTracking(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Products.Take(take).ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking").Tempo;

            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTracking, OperationType.SelectSingle);

            return tempoResult;
        }
        public TimeSpan SelectProductsSinglesAsNoTrackingHardSql(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Products.FromSqlRaw($"select top({take}) * from products").ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core single select AsNoTracking SqlHard").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTrackingSqlHard, OperationType.SelectSingle);
            return tempoResult;
        }
        public TimeSpan SelectCustomers(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _netcoreContext.Customers
                .Include(_ => _.Address)
                .Include(_ => _.Products)
                .Take(take).ToList();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCore, OperationType.SelectComplex);
            return tempoResult;
        }
        public TimeSpan SelectCustomersAsNoTracking(int take)
        {
            var watch = _consoleHelper.StartChrono();

            _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var teste = _netcoreContext.Customers
                .Where(_ => _.Address.City.StartsWith("North") && _.Products.Count(_ => _.Brand == "Intelligent") > 0)
              .Include(_ => _.Address)
              .Include(_ => _.Products)
              .Take(take)
              .ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF Core AsNoTracking").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.EfCoreAsNoTracking, OperationType.SelectComplex);
            return tempoResult;
        }
    }
}
