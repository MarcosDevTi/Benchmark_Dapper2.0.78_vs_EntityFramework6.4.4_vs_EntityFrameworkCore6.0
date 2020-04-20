using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class ResultService
    {

        private readonly DotNetCoreContext _netcoreContext;
        private readonly MessageService _messageService;
        public int InteractionElement { get; set; }
        public ResultService(DotNetCoreContext netcoreContext, MessageService messageService)
        {
            _netcoreContext = netcoreContext;
            _messageService = messageService;
        }
        public double GetMemory()
        {
            GC.GetTotalMemory(true);
            var process = Process.GetCurrentProcess();
            process.Refresh();

            return process.PrivateMemorySize64.ConvertBytesToMegabytes();
        }

        public void ClearResult(Guid id)
        {
            var result = _netcoreContext.Results.Find(id);
            if (result == null) return;
            _netcoreContext.Results.Remove(_netcoreContext.Results.Find(id));
            _netcoreContext.SaveChanges();
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
                if (typeTransaction == TypeTransaction.EfCoreAsNoTracking || typeTransaction == TypeTransaction.EfCoreAsNoTrackingSqlHard)
                {
                    _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                }

                SaveChangementResult(_netcoreContext.Results.FirstOrDefault(_ =>
        _.Amount == amount && _.OperationType == operationType && _.TypeTransaction == typeTransaction), tempoResult, ramDiference);

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

        public long CountCustomers() => _netcoreContext.Customers.Count();
        public long CountProducts() => _netcoreContext.Products.Count();

        public IEnumerable<ResultView> GetResults(OperationType operationType, params int[] sequenceAmountInteractions)
        {
            var results = new List<ResultView>();

            foreach (var inter in sequenceAmountInteractions)
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

        public ResultDetailsCell GetTempo(int amount, TypeTransaction typeTransaction, OperationType operationType)
        {
            var result = _netcoreContext.Results.FirstOrDefault(_ =>
                _.OperationType == operationType && _.TypeTransaction == typeTransaction && _.Amount == amount);

            return new ResultDetailsCell
            {
                IdResult = result?.Id,
                TempoMin = FormatTempo(result?.TempoMin),
                TempoMax = FormatTempo(result?.TempoMax),
                Ram = result?.RamMax
            };
        }

        public string FormatTempo(TimeSpan? tempo)
        {
            var result = string.Empty;
            if (tempo != null)
            {
                if (tempo?.Minutes != 0)
                {
                    result += " " + tempo?.Minutes + " minutes";
                }
                if (tempo?.Seconds != 0)
                {
                    result += " " + tempo?.Seconds + " seconds";
                }
                if (tempo?.Milliseconds != 0)
                {
                    result += " " + tempo?.Milliseconds + " milliseconds";
                }
            }
            return result;
        }

        public string FormatTempoSimplified(TimeSpan? tempo)
        {
            var result = string.Empty;
            if (tempo != null)
            {
                if (tempo?.Minutes != 0)
                {
                    result += tempo?.Minutes;
                }
                if (tempo?.Seconds != 0)
                {
                    result += tempo?.Minutes == null ? ": " : "" + tempo?.Seconds;
                }
                if (tempo?.Milliseconds != 0)
                {
                    result += tempo?.Seconds == null ? ": " : "" + tempo?.Milliseconds;
                }
            }
            return result;
        }
    }

}
