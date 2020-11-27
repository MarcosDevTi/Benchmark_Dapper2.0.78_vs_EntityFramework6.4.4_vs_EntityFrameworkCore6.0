using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System;
using System.Data;

namespace EntityFrameworkVsCoreDapper.Context
{
    public class DapperContext : IDisposable
    {
        public IDbConnection OpenedConnection { get; set; }

        public DapperContext(IConfiguration configuration)
        {
            OpenedConnection = new ProfiledDbConnection(new SqlConnection(configuration.GetConnectionString("DefaultConnection")), MiniProfiler.Current);
            OpenedConnection.Open();
        }

        public void Dispose()
        {
            if (OpenedConnection.State != ConnectionState.Closed)
                OpenedConnection.Close();
        }
    }
}
