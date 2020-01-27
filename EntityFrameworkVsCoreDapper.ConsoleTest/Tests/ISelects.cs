using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public interface ISelects
    {
        void Run();
        void AddProfileSingleSelect(int quant, string txtNum);
        void AddProfile(int quant, string txtNum);
    }
}
