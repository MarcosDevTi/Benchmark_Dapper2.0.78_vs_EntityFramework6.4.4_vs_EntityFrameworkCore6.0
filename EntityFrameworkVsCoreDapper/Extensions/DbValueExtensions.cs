using System;

namespace EntityFrameworkVsCoreDapper.Extensions
{
    public static class DbValueExtensions
    {
        public static T As<T>(this object source)
        {
            return source == null || source == DBNull.Value
                ? default(T)
                : (T)source;
        }

        public static object AsDbValue(this object source)
        {
            return source ?? DBNull.Value;
        }
    }
}
