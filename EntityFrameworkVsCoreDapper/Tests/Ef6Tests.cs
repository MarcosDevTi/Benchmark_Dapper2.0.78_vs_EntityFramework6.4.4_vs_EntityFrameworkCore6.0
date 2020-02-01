using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Results;
using System;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class Ef6Tests : IEf6Tests
    {
        private readonly ConsoleHelper _consoleHelper;
        private readonly Ef6Context _ef6Context;
        private readonly ResultService _resultService;
        public Ef6Tests(ConsoleHelper consoleHelper, Ef6Context ef6Context, ResultService resultService)
        {
            _consoleHelper = consoleHelper;
            _ef6Context = ef6Context;
            _resultService = resultService;
        }
        public TimeSpan InsertAvg(int interactions)
        {
            var tempo = TimeSpan.Zero;

            for (int i = 0; i < 10; i++)
            {
                var watch = _consoleHelper.StartChrono();

                using (var context = new Ef6Context())
                {
                    new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => context.Customers.Add(_));
                    context.SaveChanges();
                }

                watch.Watch.Stop();
                tempo += watch.Watch.Elapsed;
            }

            return _consoleHelper.DisplayChrono(tempo / 10, "EF 6");
        }
        public TimeSpan AddCustomersSingles(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersSingles(interactions).ForEach(_ => _ef6Context.Customers.Add(_));
            _ef6Context.SaveChanges();

            return _consoleHelper.StopChrono(watch, "EF 6").Tempo;
        }
        public TimeSpan AjouterCustomersAleatoires(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _ef6Context.Customers.Add(_));
            _ef6Context.SaveChanges();

            return _consoleHelper.StopChrono(watch, "EF 6").Tempo;
        }
        public TimeSpan AjouterCustomersAleatoiresOpenClose(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            foreach (var item in new ListTests().ObtenirListCustomersAleatoire(interactions))
            {
                _ef6Context.Customers.Add(item);
                _ef6Context.SaveChanges();
            }

            return _consoleHelper.StopChrono(watch, "EF 6").Tempo;
        }
        public TimeSpan SelectCustomers(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _ef6Context.Customers
                .Include(_ => _.Address)
                 .Include(_ => _.Products)
                 .Where(_ => _.Address.City.StartsWith("North") && _.Products.Any(_ => _.Brand == "Intelligent"))
                .Take(take).ToList();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6").Tempo;
            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.SelectComplex);

            return tempoResult;
        }

        public TimeSpan SelectProductsSingles(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _ef6Context.Products.Take(take).ToList();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6 single select").Tempo;

            watch.Watch.Stop();

            _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.SelectSingle);

            return tempoResult;
        }
    }
}
