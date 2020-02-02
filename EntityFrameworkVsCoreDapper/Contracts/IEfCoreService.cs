using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEfCoreService
    {
        TimeSpan InsertComplexCustomers(int interactions);
        TimeSpan InsertComplexCustomersAsNoTrackingSqlCommand(int interactions);
        TimeSpan InsertSingleProducts(int interactions);
        TimeSpan InsertSingleProductsAsNoTrackingSqlCommand(int interactions);

        TimeSpan SelectSingleProducts(int take);
        TimeSpan SelectSingleProductsAsNoTracking(int take);
        TimeSpan SelectSingleProductsAsNoTrackingSqlQuery(int take);
        TimeSpan SelectComplexCustomers(int take);
        TimeSpan SelectComplexCustomersAsNoTracking(int take);
        

    }
}
