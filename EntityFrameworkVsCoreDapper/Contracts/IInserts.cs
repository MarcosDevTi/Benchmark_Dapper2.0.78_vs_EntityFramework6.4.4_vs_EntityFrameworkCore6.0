namespace EntityFrameworkVsCoreDapper.ConsoleTest.Tests
{
    public interface IInserts
    {
        void AddProfileCustomersSingles(params int[] quant);
        void AddProfileAjouter(params int[] quant);
    }
}
