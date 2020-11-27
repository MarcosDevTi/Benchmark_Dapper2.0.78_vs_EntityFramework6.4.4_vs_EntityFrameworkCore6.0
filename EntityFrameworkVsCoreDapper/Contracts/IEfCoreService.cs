using System;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Contracts
{
    public interface IEfCoreService
    {
        Task<TimeSpan> InsertComplexCustomers(int interactions);
        Task<TimeSpan> InsertComplexCustomersAsNoTrackingSqlCommand(int interactions);
        Task<TimeSpan> InsertSingleProducts(int interactions);
        Task<TimeSpan> InsertSingleProductsAsNoTrackingSqlCommand(int interactions);

        Task<TimeSpan> SelectSingleProducts(int take);
        Task<TimeSpan> SelectSingleProductsAsNoTracking(int take);
        Task<TimeSpan> SelectSingleProductsAsNoTrackingSqlQuery(int take);
        Task<TimeSpan> SelectComplexCustomers(int take);
        Task<TimeSpan> SelectComplexCustomersAsNoTracking(int take);


    }
}
