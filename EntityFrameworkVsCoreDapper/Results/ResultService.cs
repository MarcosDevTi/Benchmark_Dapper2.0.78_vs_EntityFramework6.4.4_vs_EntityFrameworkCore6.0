using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultService
    {
        private readonly DotNetCoreContext _netcoreContext;
        public ResultService(DotNetCoreContext netcoreContext)
        {
            _netcoreContext = netcoreContext;
        }
        public double GetMemory()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            process.Refresh();
            return process.PrivateMemorySize64.ConvertBytesToMegabytes();
        }

        public void SaveSelect(int amount, TimeSpan tempoResult, double initMemory, TypeTransaction typeTransaction, OperationType operationType)
        {
            var stopMemory = GetMemory();
            var resultSave = new Result
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                OperationType = operationType,
                Tempo = tempoResult,
                TypeTransaction = typeTransaction,
                Ram = stopMemory - initMemory
            };

            var resultExisting = _netcoreContext.Results.FirstOrDefault(_ =>
            _.Amount == resultSave.Amount && _.OperationType == resultSave.OperationType && _.TypeTransaction == resultSave.TypeTransaction);
            if (resultExisting != null)
            {
                _netcoreContext.Remove(resultExisting);
            }
            _netcoreContext.Add(resultSave);
            _netcoreContext.SaveChanges();
        }

        public IEnumerable<ResultView> GetResults(OperationType operationType)
        {
            var interators = new[] { 1, 5, 50, 200, 10000, 200000, 2000000 };
            var results = new List<ResultView>();

            foreach (var inter in interators)
            {
                results.Add(new ResultView
                {
                    Dapper = new ItemResultView
                    {
                        Interactions = inter,
                        Display = GetTempo(inter, TypeTransaction.Dapper, operationType)
                    },
                    Ef6 = new ItemResultView
                    {
                        Interactions = inter,
                        Display = GetTempo(inter, TypeTransaction.Ef6, operationType)
                    },
                    EFCore = new ItemResultView
                    {
                        Interactions = inter,
                        Display = GetTempo(inter, TypeTransaction.EfCore, operationType)
                    },
                    EfCoreAsNoTracking = new ItemResultView
                    {
                        Interactions = inter,
                        Display = GetTempo(inter, TypeTransaction.EfCoreAsNoTracking, operationType)
                    },
                    EfCoreAsNoTrackingHardSql = new ItemResultView
                    {
                        Interactions = inter,
                        Display = GetTempo(inter, TypeTransaction.EfCoreAsNoTrackingSqlHard, operationType)
                    },
                });
            }

            return results;
        }

        public string GetTempo(int amount, TypeTransaction typeTransaction, OperationType operationType)
        {
            var result = _netcoreContext.Results.FirstOrDefault(_ => _.OperationType == operationType && _.TypeTransaction == typeTransaction && _.Amount == amount);
            return $"Tempo: {result?.Tempo.Minutes}:{result?.Tempo.Seconds}:{result?.Tempo.Milliseconds}, Ram: {result?.Ram}";
        }
    }
}
