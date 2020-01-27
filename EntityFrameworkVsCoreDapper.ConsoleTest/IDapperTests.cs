using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IDapperTests
    {
        void SelectProductsSingles(int take);
        void SelectCustomers(int take);
        void InsertAvg(int interactions);
        void AddCustomersSingles(int interactions);
        void AjouterCustomersAleatoires(int interactions);
    }
}
