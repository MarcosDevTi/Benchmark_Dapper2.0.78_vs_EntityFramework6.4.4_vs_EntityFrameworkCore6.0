using Newtonsoft.Json;

namespace EfVsDapper.Mvc.Helpers
{
    public class InteractionsService
    {
        public static int[] SelectComplex = new[] { 1, 200, 1000, 5000, 10000, 50000, 80000 };
        public static int[] InsertComplex = new[] { 1, 50, 100, 500, 1000, 2000, 5000 };
        public static int[] SelectSingle = new[] { 1, 50, 200, 1000, 50000, 100000, 400000 };
        public static int[] InsertSingle = new[] { 1, 5, 200, 500, 1000, 5000, 50000 };

        public static string SelectComplexJson = JsonConvert.SerializeObject(SelectComplex);
        public static string InsertComplexJson = JsonConvert.SerializeObject(InsertComplex);
        public static string SelectSingleJson = JsonConvert.SerializeObject(SelectSingle);
        public static string InsertSingleJson = JsonConvert.SerializeObject(InsertSingle);
    }
}
