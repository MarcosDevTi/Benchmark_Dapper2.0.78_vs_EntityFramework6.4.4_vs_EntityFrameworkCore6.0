using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IDapperTests
    {
        TimeSpan SelectProductsSingles(int take);
        TimeSpan SelectCustomers(int take);
        TimeSpan InsertAvg(int interactions);
        TimeSpan AddCustomersSingles(int interactions);
        TimeSpan AjouterCustomersAleatoires(int interactions);
    }
}
