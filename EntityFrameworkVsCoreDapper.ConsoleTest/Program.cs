using EntityFrameworkVsCoreDapper.ConsoleTest.Tests;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {



            _serviceProvider = new Startup().Initialize();

            RunTests();

            ReadLine();
        }

        static void RunTests()
        {
            var inserts = _serviceProvider.GetService<IInserts>();
            var selects = _serviceProvider.GetService<ISelects>();

            selects.Run();
            //new Selects();
        }
    }
}
