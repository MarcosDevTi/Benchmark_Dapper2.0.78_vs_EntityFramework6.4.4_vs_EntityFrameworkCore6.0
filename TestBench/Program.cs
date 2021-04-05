using BenchmarkDotNet.Running;

namespace TestBench
{


    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<DatabaseTestPerformance>();
            var summary2 = BenchmarkRunner.Run<SinglesInserts>();
        }
    }
}
