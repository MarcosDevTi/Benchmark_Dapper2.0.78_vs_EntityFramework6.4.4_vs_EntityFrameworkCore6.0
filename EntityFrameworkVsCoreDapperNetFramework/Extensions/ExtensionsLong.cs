namespace EntityFrameworkVsCoreDapperNetFramework.Extensions
{
    public static class ExtensionsLong
    {
        public static double ConvertBytesToMegabytes(this long bytes) => (bytes / 1024f) / 1024f;
    }
}
