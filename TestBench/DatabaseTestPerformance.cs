using BenchmarkDotNet.Attributes;
using EntityFrameworkVsCoreDapper.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TestBench.Models;

namespace TestBench
{
    public class DatabaseTestPerformance
    {
        DotNetCoreContext context;
        IDbConnection dapperConnection;
        EfCoreSingleSelect ef;
        DapperSengleSelect dapper;

        public DatabaseTestPerformance()
        {
            var connectionStrings = @"Data Source=(LocalDB)\MSSQLLocalDB; 
                               Initial Catalog=CamparationEntityDapper; Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<DotNetCoreContext>();
            optionsBuilder.UseSqlServer(connectionStrings);
            context = new DotNetCoreContext(optionsBuilder.Options);

            dapperConnection = new SqlConnection(connectionStrings);

            ef = new EfCoreSingleSelect(context);
            dapper = new DapperSengleSelect(dapperConnection);
        }

        [Benchmark]
        public IReadOnlyList<ProductDto> Ef() => ef.GetProductsEF(50);

        [Benchmark]
        public IReadOnlyList<ProductDto> Dapper() => dapper.GetProducts(50);
    }
}
