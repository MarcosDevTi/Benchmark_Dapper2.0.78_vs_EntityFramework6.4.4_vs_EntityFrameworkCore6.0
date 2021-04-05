using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Helpers;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Tests
{
    public class AdoService : IAdoService
    {
        private readonly ConsoleHelper _consoleHelper;
        private readonly ResultService _resultService;
        private readonly IConfiguration _configuration;
        public AdoService(ConsoleHelper consoleHelper, ResultService resultService, IConfiguration configuration)
        {
            _consoleHelper = consoleHelper;
            _resultService = resultService;
            _configuration = configuration;
        }

        public async Task<TimeSpan> InsertSingleProducts(int interactions)
        {
            var watch = _consoleHelper.StartChrono();


            await AddProducts(new ListTests().ObtenirListProductsAleatoire(interactions, null));

            var tempoResult = _consoleHelper.StopChrono(watch, "Ado").Tempo;

            await _resultService.SaveSelect(interactions, tempoResult, watch.InitMemory, TypeTransaction.Ado, OperationType.InsertSingle);
            return tempoResult;
        }

        public async Task InsertSingleProductsBenchmarkDotNet(int interactions)
        {
            await AddProducts(new ListTests().ObtenirListProductsAleatoire(interactions, null));
        }

        private async Task AddProducts(IEnumerable<Product> products)
        {
            using (SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (var sqlBulkCopy = new SqlBulkCopy(cnn))
                {
                    sqlBulkCopy.DestinationTableName = "efdp_product";
                    cnn.Open();
                    await sqlBulkCopy.WriteToServerAsync(BuildProductDateTable(products));
                    cnn.Close();
                }
            }
        }

        private DataTable BuildProductDateTable(IEnumerable<Product> products)
        {
            var dt = new DataTable();
            dt.Columns.Add("id", typeof(Guid));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("old_price", typeof(decimal));
            dt.Columns.Add("brand", typeof(string));


            foreach (var product in products)
                dt.Rows.Add(
                    product.Id, product.Name, product.Description, product.Price, product.OldPrice,
                    product.Brand);

            dt.AcceptChanges();

            return dt;
        }
    }
}
