using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace EntityFrameworkVsCoreDapper.Context
{
    public class DapperContext : IDisposable
    {
        public IDbConnection OpenedConnection { get; set; }
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration _configuration)
        {
            OpenedConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")); ;
            OpenedConnection.Open();
        }

        public void Dispose()
        {
            if (OpenedConnection.State != ConnectionState.Closed)
                OpenedConnection.Close();
        }
    }
}
