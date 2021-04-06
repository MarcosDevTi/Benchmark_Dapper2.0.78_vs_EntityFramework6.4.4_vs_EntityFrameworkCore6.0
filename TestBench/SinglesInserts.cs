using BenchmarkDotNet.Attributes;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Tests;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestBench
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesInserts1
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly SinglesInsertsBenchmarkDotNet _adoServiceBenchmarkDotNet;
        public SinglesInserts1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _sqlConnection = new SqlConnection(connectionStrings);
            _adoServiceBenchmarkDotNet = new SinglesInsertsBenchmarkDotNet();
            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Insert 1 Product Ado")]
        public async Task InsertProductsAdo1() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsAdo(1, _sqlConnection);

        [Benchmark(Description = "Insert 1 Product Ado SqlBulkCopy")]
        public async Task InsertProductsAdoSqlBulkCopy1() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsSqlBulkCopy(1, _sqlConnection);

        [Benchmark(Description = "Insert 1 Product Dapper")]
        public async Task InsertProductsDapper1() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsDapper(1, _sqlConnection);

        [Benchmark(Description = "Insert 1 Product Ef Core 6")]
        public async Task InsertProductsEfCore1() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEfCore(1, _efCoreContext);

        [Benchmark(Description = "Insert 1 Product Ef 6")]
        public async Task InsertProductsEf61() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEf6(1, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesInserts5
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly SinglesInsertsBenchmarkDotNet _adoServiceBenchmarkDotNet;
        public SinglesInserts5()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _sqlConnection = new SqlConnection(connectionStrings);
            _adoServiceBenchmarkDotNet = new SinglesInsertsBenchmarkDotNet();
            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Insert 5 Product Ado")]
        public async Task InsertProductsAdo5() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsAdo(5, _sqlConnection);

        [Benchmark(Description = "Insert 5 Product Ado SqlBulkCopy")]
        public async Task InsertProductsAdoSqlBulkCopy5() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsSqlBulkCopy(1, _sqlConnection);

        [Benchmark(Description = "Insert 5 Product Dapper")]
        public async Task InsertProductsDapper5() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsDapper(5, _sqlConnection);

        [Benchmark(Description = "Insert 5 Product Ef Core 6")]
        public async Task InsertProductsEfCore5() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEfCore(5, _efCoreContext);

        [Benchmark(Description = "Insert 5 Product Ef 6")]
        public async Task InsertProductsEf65() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEf6(5, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesInserts20
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly SinglesInsertsBenchmarkDotNet _adoServiceBenchmarkDotNet;
        public SinglesInserts20()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _sqlConnection = new SqlConnection(connectionStrings);
            _adoServiceBenchmarkDotNet = new SinglesInsertsBenchmarkDotNet();
            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Insert 20 Products Ado")]
        public async Task InsertProductsAdo20() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsAdo(20, _sqlConnection);

        [Benchmark(Description = "Insert 20 Products SqlBulkCopy")]
        public async Task InsertProductsAdoSqlBulkCopy20() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsSqlBulkCopy(20, _sqlConnection);

        [Benchmark(Description = "Insert 20 Products Dapper")]
        public async Task InsertProductsDapper20() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsDapper(20, _sqlConnection);

        [Benchmark(Description = "Insert 20 Products Ef Core 6")]
        public async Task InsertProductsEfCore20() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEfCore(20, _efCoreContext);

        [Benchmark(Description = "Insert 20 Products Ef 6")]
        public async Task InsertProductsEf620() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEf6(20, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesInserts200
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        private readonly SinglesInsertsBenchmarkDotNet _adoServiceBenchmarkDotNet;
        public SinglesInserts200()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);
            _sqlConnection = new SqlConnection(connectionStrings);
            _adoServiceBenchmarkDotNet = new SinglesInsertsBenchmarkDotNet();
            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Insert 200 Products Ado")]
        public async Task InsertProductsAdo200() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsAdo(200, _sqlConnection);

        [Benchmark(Description = "Insert 200 Products SqlBulkCopy")]
        public async Task InsertProductsAdoSqlBulkCopy200() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsSqlBulkCopy(200, _sqlConnection);

        [Benchmark(Description = "Insert 200 Products Dapper")]
        public async Task InsertProductsDapper200() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsDapper(200, _sqlConnection);

        [Benchmark(Description = "Insert 200 Products Ef Core 6")]
        public async Task InsertProductsEfCore200() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEfCore(200, _efCoreContext);

        [Benchmark(Description = "Insert 200 Products Ef 6")]
        public async Task InsertProductsEf200() =>
            await _adoServiceBenchmarkDotNet.InsertSingleProductsEf6(200, _ef6Context);
    }
}
