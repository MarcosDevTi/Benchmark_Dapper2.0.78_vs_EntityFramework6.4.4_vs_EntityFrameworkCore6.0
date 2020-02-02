using System;

namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public class Inserts : IInserts
    {
        private readonly IDapperService _dapperTests;

        public Inserts(IDapperService dapperTests)
        {
            _dapperTests = dapperTests;
        }

        public void AddProfileCustomersSingles(params int[] quant)
        {
            foreach (var i in quant)
                AddProfileCustomersSingles(i);
        }

        public void AddProfileAjouter(params int[] quant)
        {
            foreach (var i in quant)
                AddProfileAjouter(i);
        }

        public void AddProfileAjouter(int quant)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Insert avec {quant}");
            Console.ResetColor();

            _dapperTests.InsertComplexCustomers(quant);
        }
    }
}
