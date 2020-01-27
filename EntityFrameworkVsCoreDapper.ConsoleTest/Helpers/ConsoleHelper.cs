using System;
using System.Diagnostics;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Helpers
{
    public class ConsoleHelper
    {
        public void ShowResultFaster(string name, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Faster: " + name);
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        public void ShowFaster(TimeSpan dapper, TimeSpan efCore, TimeSpan efCoreAsNoTr, TimeSpan EfAsNoTrHardSql)
        {
            var list = new (string Name, TimeSpan Tempo, ConsoleColor Color)[]
            {
                ("Dapper", dapper, ConsoleColor.DarkBlue),
                ("Ef Core", efCore, ConsoleColor.DarkGreen),
                ("Ef Core AsNoTracking", efCoreAsNoTr, ConsoleColor.DarkGreen),
                ("Ef Core AsNoTracking Hard Sql", EfAsNoTrHardSql, ConsoleColor.DarkGreen)
            };

            var resultFaster = list.FirstOrDefault(_ => _.Tempo.TotalSeconds == list.Min(_ => _.Tempo).TotalSeconds);

            ShowResultFaster(resultFaster.Name, resultFaster.Color);
        }

        public void ShowFaster(TimeSpan dapper, TimeSpan efCore, TimeSpan efCoreAsNoTr)
        {
            var arr = new (string Name, TimeSpan Tempo, ConsoleColor Color)[]
            {
                ("Dapper", dapper, ConsoleColor.DarkBlue),
                ("Ef Core", efCore, ConsoleColor.DarkGreen),
                ("Ef Core AsNoTracking", efCoreAsNoTr, ConsoleColor.DarkGreen),
            };

            var resultFaster = arr.FirstOrDefault(_ => _.Tempo.TotalSeconds == arr.Min(_ => _.Tempo).TotalSeconds);

            ShowResultFaster(resultFaster.Name, resultFaster.Color);
        }

        public void ShowTitleSelect(string numero)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Select with: {numero} Items");
            Console.ResetColor();
        }

        public Stopwatch StartChrono()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            return stopwatch;
        }

        public TimeSpan StopChrono(Stopwatch watch, string txt)
        {
            watch.Stop();

            var result = $"Time elapsed with {txt}: {watch.Elapsed}";
            Console.WriteLine(result);
            return watch.Elapsed;
        }

        public TimeSpan DisplayChrono(TimeSpan tempo, string txt)
        {
            var result = string.Format($"Time elapsed with {txt}: {0}", tempo);
            Console.WriteLine(result);

            return tempo;
        }
    }
}
