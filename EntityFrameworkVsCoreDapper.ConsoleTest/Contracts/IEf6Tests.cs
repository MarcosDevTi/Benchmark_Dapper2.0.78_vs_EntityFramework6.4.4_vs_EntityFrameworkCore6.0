using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEf6Tests
    {
        TimeSpan InsertAvg(int interactions);
        TimeSpan AddCustomersSingles(int interactions);
        TimeSpan AjouterCustomersAleatoires(int interactions);
        TimeSpan AjouterCustomersAleatoiresOpenClose(int interactions);
        TimeSpan SelectCustomers(int take);
    }
}
