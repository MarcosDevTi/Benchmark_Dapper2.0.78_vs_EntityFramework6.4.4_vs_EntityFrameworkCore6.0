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
}
