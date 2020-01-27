using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEf6Tests
    {
        void InsertAvg(int interactions);
        void AddCustomersSingles(int interactions);
        void AjouterCustomersAleatoires(int interactions);
        void AjouterCustomersAleatoiresOpenClose(int interactions);
        void SelectCustomers(int take);
    }
}
