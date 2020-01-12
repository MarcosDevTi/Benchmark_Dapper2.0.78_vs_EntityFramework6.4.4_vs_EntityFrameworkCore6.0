using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Insertions
    {
        public Insertions()
        {
            int quant;

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 10 000");
            Console.ResetColor();
            
             quant = 10000;

            new DapperTests().AjouterCustomersAleatoires(quant);
            new Ef6Tests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTracking(quant);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 500");
            Console.ResetColor();
            quant = 500;

            new DapperTests().AjouterCustomersAleatoires(quant);
            new Ef6Tests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTracking(quant);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 20");
            Console.ResetColor();
            quant = 20;

            new DapperTests().AjouterCustomersAleatoires(quant);
            new Ef6Tests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTracking(quant);


            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Insert avec 100");
            //Console.ResetColor();
            //quant = 100;
            //new DapperTests().InsertTransactionPerItem(quant);
            //new EntityFrameworkTests().InsertTransactionPerItem(quant); 
        }
    }
}
