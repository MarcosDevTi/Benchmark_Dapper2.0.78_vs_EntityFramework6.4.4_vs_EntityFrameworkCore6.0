using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntityFrameworkVsCoreDapper.Context
{
    public class DapperContext: IDisposable
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
