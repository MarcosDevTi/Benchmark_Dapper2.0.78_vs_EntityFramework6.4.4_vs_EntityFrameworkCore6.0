namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public interface ISelects
    {
        void Run();
        void AddProfileSingleSelect(int quant);
        void AddProfileCustomer(int quant);
    }
}
