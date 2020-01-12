using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Selects
    {
        public Selects()
        {

            var quant = 5;
            Montrer("5");
            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);
            
            quant = 10;
            Montrer("10");
            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);
            
            quant = 30;
            Montrer("30");
            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            
            quant = 100;
            Montrer("100");
            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            quant = 200;
            Montrer("200");
            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            quant = 500;
            Montrer("500");
            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            Montrer("10 000");

            quant = 10000;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);


            Montrer("100 000");
            quant = 100000;

            new DapperTests().SelectCustomers(quant);
            new Ef6Tests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            Montrer("1 000 000");
            Console.ResetColor();
            quant = 1000000;

            new DapperTests().SelectCustomers(quant);
            //new Ef6Tests().SelectCustomers(quant);
            //new EntityFrameworkTests().SelectCustomers(quant);
            new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);

            //Montrer("3 500 000");
            //quant = 3500000;

            //new DapperTests().SelectCustomers(quant);
            ////new Ef6Tests().SelectCustomers(quant);
            ////new EntityFrameworkTests().SelectCustomers(quant);
            //new EntityFrameworkTests().SelectCustomersAsNoTracking(quant);
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
