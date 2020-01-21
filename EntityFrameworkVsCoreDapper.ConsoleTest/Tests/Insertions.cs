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
            Console.WriteLine("Insert avec 100");
            Console.ResetColor();

            quant = 100;

            new DapperTests().AjouterCustomersAleatoires(quant);
            new Ef6Tests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoires(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTracking(quant);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 50");
            Console.ResetColor();
            quant = 50;

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


            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 10 Open and Close");
            Console.ResetColor();
            quant = 10;

            new DapperTests().AjouterCustomersAleatoiresOpenClose(quant);
            new Ef6Tests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTrackingOpenClose(quant);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 5 Open and Close");
            Console.ResetColor();
            quant = 5;

            new DapperTests().AjouterCustomersAleatoiresOpenClose(quant);
            new Ef6Tests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTrackingOpenClose(quant);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 2 Open and Close");
            Console.ResetColor();
            quant = 2;

            new DapperTests().AjouterCustomersAleatoiresOpenClose(quant);
            new Ef6Tests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTrackingOpenClose(quant);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Insert avec 1 Open and Close");
            Console.ResetColor();
            quant = 1;

            new DapperTests().AjouterCustomersAleatoiresOpenClose(quant);
            new Ef6Tests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresOpenClose(quant);
            new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTrackingOpenClose(quant);

            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Insert avec 100 000");
            //Console.ResetColor();
            //quant = 100000;

            //new DapperTests().AjouterCustomersAleatoires(quant);
            //new Ef6Tests().AjouterCustomersAleatoires(quant);
            //new EntityFrameworkTests().AjouterCustomersAleatoires(quant);
            //new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTracking(quant);


            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Insert avec 1 000 000");
            //Console.ResetColor();
            //quant = 1000000;

            //new DapperTests().AjouterCustomersAleatoires(quant);
            //new Ef6Tests().AjouterCustomersAleatoires(quant);
            //new EntityFrameworkTests().AjouterCustomersAleatoires(quant);
            //new EntityFrameworkTests().AjouterCustomersAleatoiresAsNoTracking(quant);
        }
    }
}
