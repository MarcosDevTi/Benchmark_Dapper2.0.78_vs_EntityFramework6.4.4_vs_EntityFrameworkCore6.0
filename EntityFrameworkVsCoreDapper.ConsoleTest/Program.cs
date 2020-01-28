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

            inserts.AddProfileAjouter(1000, 10000, 5000, 1000, 10000, 5000, 1000, 10000, 5000);
            selects.Run();
            //new Selects();
        }
    }
}
