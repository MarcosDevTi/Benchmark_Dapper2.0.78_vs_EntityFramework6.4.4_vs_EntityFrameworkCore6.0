using System;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultItem : Entity
    {
        public TimeSpan Dapper { get; set; }
        public TimeSpan Ef6 { get; set; }
        public TimeSpan EfCore { get; set; }
        public TimeSpan EfCoreAsNoTracking { get; set; }
        public (string Name, TimeSpan Speed) Faster()
        {
            var arr = new (string Name, TimeSpan Tempo)[]
            {
                ("Dapper", Dapper),("Ef 6", Ef6), ("Ef Core", EfCore), ("Ef Core AsNoTracking", EfCoreAsNoTracking)
            };
            return arr.FirstOrDefault(_ => _.Tempo.TotalSeconds == arr.Min(_ => _.Tempo).TotalSeconds);
        }
    }
}
