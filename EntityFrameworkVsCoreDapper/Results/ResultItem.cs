namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultItem : Entity
    {
        public Score Dapper { get; set; }
        public Score Ef6 { get; set; }
        public Score EfCore { get; set; }
        public Score EfCoreAsNoTracking { get; set; }
        //public (string Name, TimeSpan Speed) Faster()
        //{
        //    var arr = new (string Name, TimeSpan Tempo)[]
        //    {
        //        ("Dapper", Dapper.Tempo),("Ef 6", Ef6.Tempo), ("Ef Core", EfCore.Tempo), ("Ef Core AsNoTracking", EfCoreAsNoTracking.Tempo)
        //    };
        //    return arr.FirstOrDefault(_ => _.Tempo.TotalSeconds == arr.Min(_ => _.Tempo).TotalSeconds);
        //}
    }
}
