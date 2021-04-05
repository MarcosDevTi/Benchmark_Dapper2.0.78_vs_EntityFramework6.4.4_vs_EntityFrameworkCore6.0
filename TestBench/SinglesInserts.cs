using BenchmarkDotNet.Attributes;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Tests;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestBench
{
    [MarkdownExporterAttribute.GitHub]
    public class SinglesInserts
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        public SinglesInserts()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _sqlConnection = new SqlConnection(connectionStrings);
        }

        [Benchmark]
        public async Task InsertProductsAdo1() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsAdo(1, connectionStrings);

        [Benchmark]
        public async Task InsertProductsAdoSqlBulkCopy1() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsSqlBulkCopy(1, _sqlConnection);

        [Benchmark]
        public async Task InsertProductsDapper1() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsDapper(1, _sqlConnection);

        [Benchmark]
        public async Task InsertProductsEfCore1() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsEfCore(1, _efCoreContext);

        [Benchmark]
        public async Task InsertProductsAdo20() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsAdo(20, connectionStrings);

        [Benchmark]
        public async Task InsertProductsAdoSqlBulkCopy20() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsSqlBulkCopy(20, _sqlConnection);

        [Benchmark]
        public async Task InsertProductsDapper20() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsDapper(20, _sqlConnection);

        [Benchmark]
        public async Task InsertProductsEfCore20() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsEfCore(20, _efCoreContext);

        [Benchmark]
        public async Task InsertProductsAdo200() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsAdo(200, connectionStrings);

        [Benchmark]
        public async Task InsertProductsAdoSqlBulkCopy200() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsSqlBulkCopy(200, _sqlConnection);

        [Benchmark]
        public async Task InsertProductsDapper200() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsDapper(200, _sqlConnection);

        [Benchmark]
        public async Task InsertProductsEfCore200() =>
            await new AdoServiceBenchmarkDotNet().InsertSingleProductsEfCore(200, _efCoreContext);
    }
}
