using BenchmarkDotNet.Running;

namespace TestBench
{


    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DatabaseTestPerformance>();
        }
    }
}
