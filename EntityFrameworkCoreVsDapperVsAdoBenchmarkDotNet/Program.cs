using BenchmarkDotNet.Running;

namespace EntityFrameworkCoreVsDapperVsAdoBenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}
