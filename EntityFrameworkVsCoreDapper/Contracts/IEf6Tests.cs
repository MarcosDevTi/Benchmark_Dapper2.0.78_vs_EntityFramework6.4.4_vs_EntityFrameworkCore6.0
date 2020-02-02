using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEf6Tests
    {
        TimeSpan InsertProductsSingles(int interactions);
        TimeSpan InsertAvg(int interactions);
        TimeSpan AddCustomersSingles(int interactions);
        TimeSpan AjouterCustomersAleatoires(int interactions);
        TimeSpan AjouterCustomersAleatoiresOpenClose(int interactions);
        TimeSpan SelectCustomers(int take);
        TimeSpan SelectProductsSingles(int take);
    }
}
