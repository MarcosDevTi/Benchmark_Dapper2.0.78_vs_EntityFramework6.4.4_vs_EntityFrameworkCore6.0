using System.ComponentModel;

namespace EntityFrameworkVsCoreDapper.Results
{
    public enum TypeTransaction
    {
        Dapper,
        Ef6,
        EfCore,
        EfCoreAsNoTracking,
        [Description("Ef Core AsNoTr SqlHard")]
        EfCoreAsNoTrackingSqlHard
    }
}
