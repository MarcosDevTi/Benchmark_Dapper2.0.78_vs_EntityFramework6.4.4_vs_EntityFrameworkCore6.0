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
}
