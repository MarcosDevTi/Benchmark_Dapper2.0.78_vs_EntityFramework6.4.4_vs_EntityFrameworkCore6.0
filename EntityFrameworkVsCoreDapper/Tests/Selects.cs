using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Selects : ISelects
    {
        private readonly IDapperService _dapperTests;
        private readonly IEf6Service _ef6Tests;
        private readonly IEfCoreService _efCoreTests;
        private readonly ConsoleHelper _consoleHelper;

        public Selects(IDapperService dapperTests, IEf6Service ef6Tests, IEfCoreService efCoreTests, ConsoleHelper consoleHelper)
        {
            _dapperTests = dapperTests;
            _ef6Tests = ef6Tests;
            _efCoreTests = efCoreTests;
            _consoleHelper = consoleHelper;
        }

        public void Run()
        {
            //_efCoreTests.InitInterface();
            var start = _consoleHelper.StartChrono();
            AddProfileSingleSelect(4000000);
            AddProfileCustomer(1, 2, 3, 5, 10, 20, 50, 100, 200, 500, 1000);
        }

        public void AddProfileSingleSelect(params int[] quant)
        {
            foreach (var q in quant)
                AddProfileSingleSelect(q);
        }

        public void AddProfileSingleSelect(int quant)
        {
            _consoleHelper.ShowTitleSelect(quant.ToString());

            var dapper = _dapperTests.SelectSingleProducts(quant);
            var efCore = _efCoreTests.SelectSingleProducts(quant);
            var efCoreAsNoTr = _efCoreTests.SelectSingleProductsAsNoTracking(quant);
            var EfAsNoTrHardSql = _efCoreTests.SelectSingleProductsAsNoTrackingSqlQuery(quant);

            //_consoleHelper.ShowFaster(dapper, efCore, efCoreAsNoTr, EfAsNoTrHardSql);
        }

        public void AddProfileCustomer(params int[] quant)
        {
            foreach (var q in quant)
                AddProfileCustomer(q);
        }

        public void AddProfileCustomer(int quant)
        {
            _consoleHelper.ShowTitleSelect(quant.ToString());

            var dapper = _dapperTests.SelectComplexCustomers(quant);
            var ef6 = _ef6Tests.SelectComplexCustomers(quant);
            var efCore = _efCoreTests.SelectComplexCustomers(quant);
            var efCoreAsNoTr = _efCoreTests.SelectComplexCustomersAsNoTracking(quant);

            _consoleHelper.ShowFaster(dapper, efCore, efCoreAsNoTr);
        }
    }
}
