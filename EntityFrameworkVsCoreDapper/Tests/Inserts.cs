using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Inserts : IInserts
    {
        private readonly IDapperService _dapperTests;
        private readonly IEf6Service _ef6Tests;
        private readonly IEfCoreService _efCoreTests;
        public Inserts(IDapperService dapperTests, IEf6Service ef6Tests, IEfCoreService efCoreTests)
        {
            _dapperTests = dapperTests;
            _ef6Tests = ef6Tests;
            _efCoreTests = efCoreTests;
        }

        public void AddProfileCustomersSingles(params int[] quant)
        {
            foreach (var i in quant)
                AddProfileCustomersSingles(i);
        }
        public void AddProfileCustomersSingles(int quant)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Insert avec {quant}");
            Console.ResetColor();

            _dapperTests.AddCustomersSingles(quant);
            _ef6Tests.AddCustomersSingles(quant);
            _efCoreTests.AddCustomersSingles(quant);
            _efCoreTests.AddCustomersSinglesAsNoTracking(quant);
        }

        public void AddProfileAjouter(params int[] quant)
        {
            foreach (var i in quant)
                AddProfileAjouter(i);
        }

        public void AddProfileAjouter(int quant)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Insert avec {quant}");
            Console.ResetColor();

            _dapperTests.AjouterCustomersAleatoires(quant);
            //new Ef6Tests().AjouterCustomersAleatoires(quant);
            //new EfCoreTests().AjouterCustomersAleatoires(quant);
            //new EfCoreTests().AjouterCustomersAleatoiresAsNoTracking(quant);
        }
    }
}
