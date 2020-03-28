using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;
using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Results;
using System;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class Ef6Service : IEf6Service
    {
        private readonly ConsoleHelper _consoleHelper;
        private readonly Ef6Context _ef6Context;
        private readonly ResultService _resultService;
        public Ef6Service(ConsoleHelper consoleHelper, Ef6Context ef6Context, ResultService resultService)
        {
            _consoleHelper = consoleHelper;
            _ef6Context = ef6Context;
            _resultService = resultService;
        }
       
        public TimeSpan InsertComplexCustomers(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ => _ef6Context.Customers.Add(_));
            _ef6Context.SaveChanges();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.InsertComplex);
            return tempoResult;
        }
        public TimeSpan InsertSingleProducts(int interactions)
        {
            var watch = _consoleHelper.StartChrono();
            var aa = new ListTests().ObtenirListProductsAleatoire(interactions, null);

            new ListTests().ObtenirListProductsAleatoire(interactions, null).ForEach(_ => _ef6Context.Products.Add(_));
            _ef6Context.SaveChanges();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6 single select").Tempo;
            _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.InsertSingle);
            return tempoResult;
        }

        public TimeSpan SelectComplexCustomers(int take)
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
        public TimeSpan SelectSingleProducts(int take)
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
