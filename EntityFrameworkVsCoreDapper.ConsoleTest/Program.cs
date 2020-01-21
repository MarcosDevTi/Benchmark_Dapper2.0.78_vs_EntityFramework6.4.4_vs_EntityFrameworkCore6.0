using Bogus;
using EntityFrameworkVsCoreDapper.ConsoleTest.Automapper;
using EntityFrameworkVsCoreDapper.ConsoleTest.Tests;
using EntityFrameworkVsCoreDapper.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new Insertions();
            //new Selects();
            new AutoMapperTest(300000);

            Console.ReadLine();
        }
    }
}
