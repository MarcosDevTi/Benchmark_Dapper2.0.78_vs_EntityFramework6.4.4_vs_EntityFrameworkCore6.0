using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEfCoreService
    {
        TimeSpan AddCustomersSingles(int interactions);
        TimeSpan AddCustomersSinglesAsNoTracking(int interactions);
        TimeSpan AjouterCustomersAleatoires(int interactions);
        TimeSpan AjouterCustomersAleatoiresOpenClose(int interactions);
        TimeSpan AjouterCustomersAleatoiresAsNoTracking(int interactions);
        TimeSpan InsertCustomerSingleAsNotrackingHardSql(int interactions);
        TimeSpan AjouterCustomersAleatoiresAsNoTrackingOpenClose(int interactions);
        TimeSpan SelectProductsSingles(int take);
        TimeSpan SelectProductsSinglesAsNoTracking(int take);
        TimeSpan SelectProductsSinglesAsNoTrackingHardSql(int take);
        TimeSpan SelectCustomers(int take);
        TimeSpan SelectCustomersAsNoTracking(int take);
        TimeSpan InsertProductsSingles(int interactions);
        TimeSpan InsertProductSingleAsNoTrackingHardSql(int interactions);

    }
}
