using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Inserts: IInserts
    {
        private readonly IDapperTests _dapperTests;
        private readonly IEf6Tests _ef6Tests;
        private readonly IEfCoreTests _efCoreTests;
        public Inserts(IDapperTests dapperTests, IEf6Tests ef6Tests, IEfCoreTests efCoreTests)
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

        public void AddProfileInsertAvg(params int[] quant)
        {
            foreach (var i in quant)
                AddProfileInsertAvg(i);
        }

        public void AddProfileInsertAvg(int quant)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Insert avec {quant}");
            Console.ResetColor();

            _dapperTests.InsertAvg(quant);
            _ef6Tests.InsertAvg(quant);
            _efCoreTests.InsertAvg(quant);
            _efCoreTests.InsertAvgAsNoTracking(quant);
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

            new DapperTests().AjouterCustomersAleatoires(quant);
            //new Ef6Tests().AjouterCustomersAleatoires(quant);
            //new EfCoreTests().AjouterCustomersAleatoires(quant);
            //new EfCoreTests().AjouterCustomersAleatoiresAsNoTracking(quant);
        }

        //public void AddProfileOpenClose(int quant)
        //{
        //    Console.BackgroundColor = ConsoleColor.Blue;
        //    Console.WriteLine($"Insert avec {quant} Open and Close");
        //    Console.ResetColor();

        //    new Ef6Tests().AjouterCustomersAleatoiresOpenClose(quant);
        //    new EfCoreTests().AjouterCustomersAleatoiresOpenClose(quant);
        //    new EfCoreTests().AjouterCustomersAleatoiresAsNoTrackingOpenClose(quant);
        //}
    }
}
