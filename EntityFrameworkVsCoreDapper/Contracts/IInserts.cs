using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public interface IInserts
    {
        void AddProfileCustomersSingles(params int[] quant);
        void AddProfileInsertAvg(params int[] quant);
        void AddProfileAjouter(params int[] quant);
    }
}
