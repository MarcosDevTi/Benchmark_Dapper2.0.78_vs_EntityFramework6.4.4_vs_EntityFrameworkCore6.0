
using BenchmarkDotNet.Running;

namespace TestBench
{


    class Program
    {
        static void Main(string[] args)
        {
            //var summary2 = BenchmarkRunner.Run<SinglesInserts1>();
            //summary2 = BenchmarkRunner.Run<SinglesInserts5>();
            //summary2 = BenchmarkRunner.Run<SinglesInserts20>();
            //summary2 = BenchmarkRunner.Run<SinglesInserts200>();

            var summarySelect1 = BenchmarkRunner.Run<SinglesSelects1>();
            summarySelect1 = BenchmarkRunner.Run<SinglesSelects5>();
            summarySelect1 = BenchmarkRunner.Run<SinglesSelects50>();
            summarySelect1 = BenchmarkRunner.Run<SinglesSelects500>();
            summarySelect1 = BenchmarkRunner.Run<SinglesSelects5000>();
        }
    }
}
