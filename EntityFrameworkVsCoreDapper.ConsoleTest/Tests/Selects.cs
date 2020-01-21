using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Selects
    {
        public Selects()
        {
            int quant;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select avec 100");
            Console.ResetColor();
            
            quant = 100;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select avec 10 000");
            Console.ResetColor();
            
            quant = 10000;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);


            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select avec 100 000");
            Console.ResetColor();
            quant = 100000;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select avec 1 000 000");
            Console.ResetColor();
            quant = 1000000;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            Montrer("3 500 000");
            quant = 3500000;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);
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
