using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.Extensions
{
    public static class ExtensionsLong
    {
        public static double ConvertBytesToMegabytes(this long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
