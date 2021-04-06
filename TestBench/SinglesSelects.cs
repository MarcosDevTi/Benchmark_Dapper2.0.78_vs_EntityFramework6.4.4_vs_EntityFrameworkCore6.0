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
    public class SinglesSelects1
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly SinglesSelectsBenchmarkDotNet _singlesSelects;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        public SinglesSelects1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);

            _singlesSelects = new SinglesSelectsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);

            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Select 1 Product Ado")]
        public async Task SelectProductsAdo1() =>
            await _singlesSelects.SelectSingleProductsAdo(1, _sqlConnection);

        [Benchmark(Description = "Select 1 Product Dapper")]
        public async Task SelectProductsDapper1() =>
            await _singlesSelects.SelectSingleProductsDapper(1, _sqlConnection);

        [Benchmark(Description = "Select 1 Product Ef Core 6")]
        public async Task SelectProductsEfCore61() =>
            await _singlesSelects.SelectSingleProductsEfCore(1, _efCoreContext);

        [Benchmark(Description = "Select 1 Product Ef 6")]
        public async Task SelectProductsEf61() =>
            await _singlesSelects.SelectSingleProductsEf6(1, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesSelects5
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly SinglesSelectsBenchmarkDotNet _singlesSelects;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        public SinglesSelects5()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);

            _singlesSelects = new SinglesSelectsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);

            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Select 5 Product Ado")]
        public async Task SelectProductsAdo5() =>
            await _singlesSelects.SelectSingleProductsAdo(5, _sqlConnection);

        [Benchmark(Description = "Select 5 Product Dapper")]
        public async Task SelectProductsDapper5() =>
            await _singlesSelects.SelectSingleProductsDapper(5, _sqlConnection);

        [Benchmark(Description = "Select 5 Product Ef Core 6")]
        public async Task SelectProductsEfCore65() =>
            await _singlesSelects.SelectSingleProductsEfCore(5, _efCoreContext);

        [Benchmark(Description = "Select 5 Product Ef 6")]
        public async Task SelectProductsEf65() =>
            await _singlesSelects.SelectSingleProductsEf6(5, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesSelects50
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly SinglesSelectsBenchmarkDotNet _singlesSelects;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        public SinglesSelects50()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);

            _singlesSelects = new SinglesSelectsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);

            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Select 50 Product Ado")]
        public async Task SelectProductsAdo50() =>
            await _singlesSelects.SelectSingleProductsAdo(50, _sqlConnection);

        [Benchmark(Description = "Select 50 Product Dapper")]
        public async Task SelectProductsDapper50() =>
            await _singlesSelects.SelectSingleProductsDapper(50, _sqlConnection);

        [Benchmark(Description = "Select 50 Product Ef Core 6")]
        public async Task SelectProductsEfCore650() =>
            await _singlesSelects.SelectSingleProductsEfCore(50, _efCoreContext);

        [Benchmark(Description = "Select 50 Product Ef 6")]
        public async Task SelectProductsEf65() =>
            await _singlesSelects.SelectSingleProductsEf6(50, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesSelects500
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly SinglesSelectsBenchmarkDotNet _singlesSelects;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        public SinglesSelects500()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);

            _singlesSelects = new SinglesSelectsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);

            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Select 500 Product Ado")]
        public async Task SelectProductsAdo500() =>
            await _singlesSelects.SelectSingleProductsAdo(500, _sqlConnection);

        [Benchmark(Description = "Select 500 Product Dapper")]
        public async Task SelectProductsDapper500() =>
            await _singlesSelects.SelectSingleProductsDapper(500, _sqlConnection);

        [Benchmark(Description = "Select 500 Product Ef Core 6")]
        public async Task SelectProductsEfCore6500() =>
            await _singlesSelects.SelectSingleProductsEfCore(500, _efCoreContext);

        [Benchmark(Description = "Select 500 Product Ef 6")]
        public async Task SelectProductsEf6500() =>
            await _singlesSelects.SelectSingleProductsEf6(500, _ef6Context);
    }

    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    public class SinglesSelects5000
    {
        private readonly string connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        private readonly SinglesSelectsBenchmarkDotNet _singlesSelects;
        private readonly DotNetCoreContext _efCoreContext;
        private readonly Ef6Context _ef6Context;
        public SinglesSelects5000()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            _efCoreContext = new DotNetCoreContext(optionsBuilder.Options);

            _singlesSelects = new SinglesSelectsBenchmarkDotNet();
            _sqlConnection = new SqlConnection(connectionStrings);

            _ef6Context = new Ef6Context();
        }

        [Benchmark(Description = "Select 5000 Product Ado")]
        public async Task SelectProductsAdo5000() =>
            await _singlesSelects.SelectSingleProductsAdo(5000, _sqlConnection);

        [Benchmark(Description = "Select 5000 Product Dapper")]
        public async Task SelectProductsDapper5000() =>
            await _singlesSelects.SelectSingleProductsDapper(5000, _sqlConnection);

        [Benchmark(Description = "Select 5000 Product Ef Core 6")]
        public async Task SelectProductsEfCore65000() =>
            await _singlesSelects.SelectSingleProductsEfCore(5000, _efCoreContext);

        [Benchmark(Description = "Select 5000 Product Ef 6")]
        public async Task SelectProductsEf65000() =>
            await _singlesSelects.SelectSingleProductsEf6(5000, _ef6Context);
    }
}
