using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Selects: ISelects
    {
        private readonly IDapperTests _dapperTests;
        private readonly IEf6Tests _ef6Tests;
        private readonly IEfCoreTests _efCoreTests;

        public Selects(IDapperTests dapperTests, IEf6Tests ef6Tests, IEfCoreTests efCoreTests)
        {
            _dapperTests = dapperTests;
            _ef6Tests = ef6Tests;
            _efCoreTests = efCoreTests;
        }

        public void Run()
        {
            AddProfileSingleSelect(4000000, "4 000 000");

            AddProfile(5, "5");

            AddProfile(100000, "100 000");

            AddProfile(5, "5");
            AddProfile(10, "10");
            AddProfile(20, "20");
            AddProfile(50, "50");
            AddProfile(100, "100");
            AddProfile(500, "500");
            AddProfile(10000, "10 000");
            AddProfile(50000, "50 000");
            AddProfile(100000, "100 000");
        }

        public void AddProfileSingleSelect(int quant, string txtNum)
        {
            Montrer(txtNum);

            _dapperTests.SelectProductsSingles(quant);
            _efCoreTests.SelectProductsSingles(quant);
            _efCoreTests.SelectProductsSinglesAsNoTracking(quant);
            _efCoreTests.SelectProductsSinglesAsNoTrackingHardSql(quant);
        }

        public void AddProfile(int quant, string txtNum)
        {
            Montrer(txtNum);

            _dapperTests.SelectCustomers(quant);
            _ef6Tests.SelectCustomers(quant);
            _efCoreTests.SelectCustomers(quant);
            _efCoreTests.SelectCustomersAsNoTracking(quant);
        }

        public void Montrer(string numero)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(numero);
            Console.ResetColor();
        }
    }
}
