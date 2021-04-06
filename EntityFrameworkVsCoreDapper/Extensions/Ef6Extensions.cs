using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.Extensions
{
    public static class Ef6Extensions
    {
        public static async Task<List<TSource>> ToListEf6Async<TSource>(this IQueryable<TSource> source) =>
            await source.ToListAsync();
    }
}
