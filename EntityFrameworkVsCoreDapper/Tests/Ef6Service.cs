using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Helpers;
using EntityFrameworkVsCoreDapper.Results;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Tests
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

        public async Task<TimeSpan> InsertComplexCustomers(int interactions)
        {
            var watch = _consoleHelper.StartChrono();

            new ListTests().ObtenirListCustomersAleatoire(interactions).ForEach(_ =>
                 _ef6Context.Customers.Add(_));
            await _ef6Context.SaveChangesAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory,
                TypeTransaction.Ef6, OperationType.InsertComplex);
            return tempoResult;
        }
        public async Task<TimeSpan> InsertSingleProducts(int interactions)
        {
            var watch = _consoleHelper.StartChrono();
            var aa = new ListTests().ObtenirListProductsAleatoire(interactions, null);

            new ListTests().ObtenirListProductsAleatoire(interactions, null).ForEach(_ =>
                _ef6Context.Products.Add(_));
            await _ef6Context.SaveChangesAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6 single select").Tempo;
            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.InsertSingle);
            return tempoResult;
        }

        public async Task<TimeSpan> SelectComplexCustomers(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = _ef6Context.Customers
                .Where(_ => _.FirstName != "Teste firstName" && !_.Address.City.StartsWith("Teste") && _.Products.Any(_ => _.Description != "desc test"))
                .Take(take);

            var sql = teste.ToString();

            _ = await teste.ToListAsync();

            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6").Tempo;
            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.SelectComplex);

            return tempoResult;
        }
        public async Task<TimeSpan> SelectSingleProducts(int take)
        {
            var watch = _consoleHelper.StartChrono();

            var teste = await _ef6Context.Products.Take(take).ToListAsync();
            var tempoResult = _consoleHelper.StopChrono(watch, "EF 6 single select").Tempo;

            watch.Watch.Stop();

            await _resultService.SaveSelect(take, tempoResult, watch.InitMemory, TypeTransaction.Ef6, OperationType.SelectSingle);

            return tempoResult;
        }
    }
}
