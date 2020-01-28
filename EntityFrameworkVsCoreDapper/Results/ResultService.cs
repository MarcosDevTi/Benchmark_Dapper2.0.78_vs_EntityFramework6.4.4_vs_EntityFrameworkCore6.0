using EntityFrameworkVsCoreDapper.Extensions;
using System.Collections.Generic;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultService
    {
        public ICollection<ResultItem> ResultItems { get; set; }
        public ResultService() => ResultItems = new List<ResultItem>();
        public void AddResultItem(ResultItem resultItem) => ResultItems.Add(resultItem);

        public double GetMemory()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            process.Refresh();
            return process.PrivateMemorySize64.ConvertBytesToMegabytes();
        }
    }
}
