using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IDapperService
    {
        TimeSpan SelectProductsSingles(int take);
        TimeSpan SelectCustomers(int take);

        TimeSpan InsertProductsSingles(int interactions);
        TimeSpan AddCustomersSingles(int interactions);
        TimeSpan AjouterCustomersAleatoires(int interactions);
    }
}
