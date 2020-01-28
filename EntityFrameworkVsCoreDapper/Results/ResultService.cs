using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Extensions;
using System;
using System.Collections.Generic;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultService
    {
        private readonly DotNetCoreContext _dotNetCoreContext;
        public ResultService(DotNetCoreContext dotNetCoreContext)
        {
            _dotNetCoreContext = dotNetCoreContext;
        }
        public ICollection<ResultItem> ResultItems { get; set; }
        public ResultService() => ResultItems = new List<ResultItem>();
        public void AddResultItem(ResultItem resultItem) => ResultItems.Add(resultItem);

        public double GetMemory()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            process.Refresh();
            return process.PrivateMemorySize64.ConvertBytesToMegabytes();
        }

        public void SaveScore((TimeSpan Tempo, double Ram) result, TypeTransaction typeTransaction, int take, TypeObject typeObject)
        {
            var score = new Score
            {
                Id = Guid.NewGuid(),
                Ram = result.Ram,
                Tempo = result.Tempo,
                TypeTransaction = typeTransaction,
                Take = take,
                TypeObject = typeObject
            };
            _dotNetCoreContext.Add(score);
            _dotNetCoreContext.SaveChanges();
        }
    }
}
