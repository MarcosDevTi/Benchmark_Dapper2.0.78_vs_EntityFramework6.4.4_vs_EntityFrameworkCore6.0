namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultView
    {
        public ItemResultView Dapper { get; set; }
        public ItemResultView Ef6 { get; set; }
        public ItemResultView EFCore { get; set; }
        public ItemResultView EfCoreAsNoTracking { get; set; }
        public ItemResultView EfCoreAsNoTrackingHardSql { get; set; }
    }

    public class ResultViewReflection
    {
        public ItemResultView CreateListNormally { get; set; }
        public ItemResultView CreateListWithReflection { get; set; }
        public ItemResultView CallAddNormally { get; set; }
        public ItemResultView CallAddWithReflection { get; set; }
    }

    public class ResultViewChart
    {
        public string Dapper { get; set; }
        public string Ef6 { get; set; }
        public string EFCore { get; set; }
        public string EfCoreAsNoTracking { get; set; }
        public string EfCoreAsNoTrackingHardSql { get; set; }
    }
}
