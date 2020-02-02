using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEf6Service
    {
        TimeSpan InsertProductsSingles(int interactions);
        TimeSpan AddCustomersSingles(int interactions);
        TimeSpan AjouterCustomersAleatoires(int interactions);
        TimeSpan AjouterCustomersAleatoiresOpenClose(int interactions);
        TimeSpan SelectCustomers(int take);
        TimeSpan SelectProductsSingles(int take);
    }
}
