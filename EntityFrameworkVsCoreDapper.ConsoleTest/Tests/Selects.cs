using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Selects
    {
        public Selects()
        {
            AddProfile(5, "5");
            AddProfile(10, "10");
            AddProfile(20, "20");
            AddProfile(50, "50");
            AddProfile(100, "100");
            AddProfile(500, "500");
            AddProfile(10000, "10 000");
            AddProfile(50000, "50 000");
            AddProfile(100000, "100 000");
            //AddProfile(100000, "100 000");
            //AddProfile(1000000, "1 000 000");
            //AddProfile(3500000, "3 500 000");
        }

        public void AddProfile(int quant, string txtNum)
        {
            Montrer(txtNum);

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EfCoreTests().SelectCustomers(quant);
            new EfCoreTests().SelectCustomersAsNoTracking(quant);
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
