using EntityFrameworkVsCoreDapper.ConsoleTest.Helpers;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Selects : ISelects
    {
        private readonly IDapperTests _dapperTests;
        private readonly IEf6Tests _ef6Tests;
        private readonly IEfCoreTests _efCoreTests;
        private readonly ConsoleHelper _consoleHelper;

        public Selects(IDapperTests dapperTests, IEf6Tests ef6Tests, IEfCoreTests efCoreTests, ConsoleHelper consoleHelper)
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


            //   AddProfileCustomer(1, 2, 3, 5, 10, 20, 50, 100, 200, 500, 1000);
        }

        public void AddProfileSingleSelect(params int[] quant)
        {
            foreach (var q in quant)
                AddProfileSingleSelect(q);
        }

        public void AddProfileSingleSelect(int quant)
        {
            _consoleHelper.ShowTitleSelect(quant.ToString());

            var dapper = _dapperTests.SelectProductsSingles(quant);
            var efCore = _efCoreTests.SelectProductsSingles(quant);
            var efCoreAsNoTr = _efCoreTests.SelectProductsSinglesAsNoTracking(quant);
            var EfAsNoTrHardSql = _efCoreTests.SelectProductsSinglesAsNoTrackingHardSql(quant);

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

            var dapper = _dapperTests.SelectCustomers(quant);
            var ef6 = _ef6Tests.SelectCustomers(quant);
            var efCore = _efCoreTests.SelectCustomers(quant);
            var efCoreAsNoTr = _efCoreTests.SelectCustomersAsNoTracking(quant);

             _consoleHelper.ShowFaster(dapper, efCore, efCoreAsNoTr);
        }
    }
}
