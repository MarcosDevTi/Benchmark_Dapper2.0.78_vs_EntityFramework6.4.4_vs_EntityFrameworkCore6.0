using System;

namespace EntityFrameworkVsCoreDapperNetFramework.Contracts
{
    public interface IDapperService
    {
        TimeSpan SelectSingleProducts(int take);
        TimeSpan SelectComplexCustomers(int take);

        TimeSpan InsertSingleProducts(int interactions);
        TimeSpan InsertComplexCustomers(int interactions);
    }
}
