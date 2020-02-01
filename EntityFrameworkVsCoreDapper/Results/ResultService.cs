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
        private readonly MessageService _messageService;
        public ResultService(DotNetCoreContext netcoreContext, MessageService messageService)
        {
            _netcoreContext = netcoreContext;
            _messageService = messageService;
        }
        public double GetMemory()
        {
            GC.GetTotalMemory(true);
            var process = System.Diagnostics.Process.GetCurrentProcess();
            process.Refresh();

            return process.PrivateMemorySize64.ConvertBytesToMegabytes();
        }



        public void SaveSelect(int amount, TimeSpan tempoResult, double initMemory, TypeTransaction typeTransaction, OperationType operationType)
        {
            var stopMemory = GetMemory();
            var ramDiference = stopMemory - initMemory;

            _messageService.SetLastResult(amount, tempoResult, ramDiference, typeTransaction, operationType, stopMemory);

            var resultsTracked = _netcoreContext.Results.Where(_ =>
            _.Amount == amount && _.OperationType == operationType && _.TypeTransaction == typeTransaction);
            ManageResult(resultsTracked);

            var resultTracked = resultsTracked.FirstOrDefault();

            if (resultTracked == null)
            {
                var resultSave = new Result
                {
                    Id = Guid.NewGuid(),
                    Amount = amount,
                    OperationType = operationType,
                    TypeTransaction = typeTransaction,
                    RamMax = ramDiference,
                    RamMin = ramDiference,
                    TempoMax = tempoResult,
                    TempoMin = tempoResult
                };

                _netcoreContext.Add(resultSave);
                _netcoreContext.SaveChanges();


            }
            else
            {
                SaveChangementResult(resultTracked, tempoResult, ramDiference);

            }

        }



        public void ManageResult(IEnumerable<Result> resultsTrackeds)
        {
            if (resultsTrackeds.Count() > 1)
            {
                var bestTempo = resultsTrackeds.Min(_ => _.TempoMin);
                _netcoreContext.RemoveRange(_netcoreContext.Results.Where(_ => _.TempoMin != bestTempo));
                _netcoreContext.SaveChanges();
            }
        }

        public void SaveChangementResult(Result databaseResultTracked, TimeSpan tempo, double ram)
        {
            var changed = false;
            if (tempo > databaseResultTracked.TempoMax)
            {
                databaseResultTracked.TempoMax = tempo;
                changed = true;
            }
            if (tempo < databaseResultTracked.TempoMin)
            {
                databaseResultTracked.TempoMin = tempo;
                changed = true;
            }
            if (ram > databaseResultTracked.RamMax)
            {
                databaseResultTracked.RamMax = ram;
                changed = true;
            }
            if (ram < databaseResultTracked.RamMin)
            {
                databaseResultTracked.RamMin = ram;
                changed = true;
            }
            if (changed)
            {
                _netcoreContext.SaveChanges();
            }
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

            var txtResult = "Min: " + FormatTempo(result?.TempoMin);
            txtResult += "\n\rMax: " + FormatTempo(result?.TempoMax);
            txtResult += $"\n\rRam: {result?.RamMax}";

            return txtResult;
        }

        public string FormatTempo(TimeSpan? tempo)
        {
            var result = string.Empty;
            if (tempo != null)
            {
                if (tempo?.Minutes != 0)
                {
                    result += "Min: " + tempo?.Minutes;
                }
                if (tempo?.Seconds != 0)
                {
                    result += "Sec: " + tempo?.Seconds;
                }
                if (tempo?.Milliseconds != 0)
                {
                    result += "Millsec: " + tempo?.Milliseconds;
                }
            }
            return result;
        }
    }


}
