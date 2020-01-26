using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Insertions
    {
        public Insertions()
        {
            //AddProfileInsertAvg(1, 2, 5, 10, 20, 200);
            //AddProfileCustomersSingles(2, 5, 10, 20, 50, 500, 1000, 10000);
            AddProfileAjouter(10000, 10000, 13, 45, 46, 5555, 10000);
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

            new DapperTests().AddCustomersSingles(quant);
            new Ef6Tests().AddCustomersSingles(quant);
            new EfCoreTests().AddCustomersSingles(quant);
            new EfCoreTests().AddCustomersSinglesAsNoTracking(quant);
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

            new DapperTests().InsertAvg(quant);
            new Ef6Tests().InsertAvg(quant);
            new EfCoreTests().InsertAvg(quant);
            new EfCoreTests().InsertAvgAsNoTracking(quant);
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
            new EfCoreTests().AjouterCustomersAleatoires(quant);
            new EfCoreTests().AjouterCustomersAleatoiresAsNoTracking(quant);
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
