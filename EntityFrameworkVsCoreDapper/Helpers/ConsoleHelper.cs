using EntityFrameworkVsCoreDapper.Results;
using System;
using System.Diagnostics;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Helpers
{
    public class ConsoleHelper
    {
        private readonly ResultService _resultService;
        public ConsoleHelper(ResultService resultService)
        {
            _resultService = resultService;
        }

        public (Stopwatch Watch, double InitMemory) StartChrono()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var initMemory = _resultService.GetMemory();
            return (stopwatch, initMemory);
        }

        public (TimeSpan Tempo, double Ram) StopChrono((Stopwatch Watch, double InitMemory) watch, string txt)
        {
            var stopMemory = _resultService.GetMemory();
            watch.Watch.Stop();

            var result = $"Time elapsed with {txt}: {watch.Watch.Elapsed}, {stopMemory - watch.InitMemory} MB";
            Console.WriteLine(result);
            return (watch.Watch.Elapsed, stopMemory - watch.InitMemory);
        }
    }
}
