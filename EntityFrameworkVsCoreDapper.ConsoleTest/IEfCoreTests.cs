using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public interface IEfCoreTests
    {
        void InsertAvg(int interactions);
        void InsertAvgAsNoTracking(int interactions);
        void AddCustomersSingles(int interactions);
        void AddCustomersSinglesAsNoTracking(int interactions);
        void AjouterCustomersAleatoires(int interactions);
        void AjouterCustomersAleatoiresOpenClose(int interactions);
        void AjouterCustomersAleatoiresAsNoTracking(int interactions);
        void AjouterCustomersAleatoiresAsNoTrackingOpenClose(int interactions);
        void SelectProductsSingles(int take);
        void SelectProductsSinglesAsNoTracking(int take);
        void SelectProductsSinglesAsNoTrackingHardSql(int take);
        void SelectCustomers(int take);
        void SelectCustomersAsNoTracking(int take);
    }
}
