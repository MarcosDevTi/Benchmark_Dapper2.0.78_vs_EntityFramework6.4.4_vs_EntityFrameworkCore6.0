using System;
using System.Data;
using System.Data.SqlClient;

namespace EntityFrameworkVsCoreDapperNetFramework.Context
{
    public class DapperContext : IDisposable
    {
        public IDbConnection OpenedConnection { get; set; }

        public DapperContext()
        {
            var connStrings = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=CamparationEntityDapper; Integrated Security=True";
            OpenedConnection = new SqlConnection(connStrings); ;
            OpenedConnection.Open();
        }

        public void Dispose()
        {
            if (OpenedConnection.State != ConnectionState.Closed)
                OpenedConnection.Close();
        }
    }
}
