using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Extensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task ClearResult(Guid id)
        {
            var result = await _netcoreContext.Results.FindAsync(id);
            if (result == null) return;
            var itemForRemove = await _netcoreContext.Results.FindAsync(id);
            if (itemForRemove == null) return;

            _netcoreContext.Results.Remove(itemForRemove);
            await _netcoreContext.SaveChangesAsync();
        }

        public async Task SaveSelect(int amount, TimeSpan tempoResult, double initMemory, TypeTransaction typeTransaction, OperationType operationType)
        {
            var stopMemory = GetMemory();
            var ramDiference = stopMemory - initMemory;

            _messageService.SetLastResult(amount, tempoResult, ramDiference, typeTransaction, operationType, stopMemory);

            var resultsTracked = _netcoreContext.Results.Where(_ =>
            _.Amount == amount && _.OperationType == operationType && _.TypeTransaction == typeTransaction);
            ManageResult(resultsTracked);

            var resultTracked = await resultsTracked.FirstOrDefaultAsync();

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

                await _netcoreContext.AddAsync(resultSave);
                await _netcoreContext.SaveChangesAsync();
            }
            else
            {
                if (typeTransaction == TypeTransaction.EfCoreAsNoTracking || typeTransaction == TypeTransaction.EfCoreAsNoTrackingSqlHard)
                {
                    _netcoreContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                }

                await SaveChangementResult(await _netcoreContext.Results.FirstOrDefaultAsync(_ =>
                    _.Amount == amount && _.OperationType == operationType &&
                    _.TypeTransaction == typeTransaction), tempoResult, ramDiference);
            }
        }

        public void ManageResult(IEnumerable<Result> resultsTrackeds)
        {
            if (resultsTrackeds.Count() > 1)
            {
                //var bestTempo = resultsTrackeds.Min(_ => _.TempoMin);
                //_netcoreContext.RemoveRange(_netcoreContext.Results.Where(_ => _.TempoMin != bestTempo));
                //_netcoreContext.SaveChanges();
            }
        }

        public async Task SaveChangementResult(Result databaseResultTracked, TimeSpan tempo, double ram)
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
                await _netcoreContext.SaveChangesAsync();
            }
        }

        public async Task<long> CountCustomers() => await _netcoreContext.Customers.CountAsync();
        public async Task<long> CountProducts() => await _netcoreContext.Products.CountAsync();

        public async Task<ResultViewChart> GetResultsChart(OperationType operationType, params int[] sequenceAmountInteractions)
        {
            var result = new ResultViewChart
            {
                Dapper = await GetTempoChart(sequenceAmountInteractions, TypeTransaction.Dapper, operationType),
                Ef6 = await GetTempoChart(sequenceAmountInteractions, TypeTransaction.Ef6, operationType),
                EFCore = await GetTempoChart(sequenceAmountInteractions, TypeTransaction.EfCore, operationType),
                EfCoreAsNoTracking = await GetTempoChart(sequenceAmountInteractions, TypeTransaction.EfCoreAsNoTracking, operationType),
                EfCoreAsNoTrackingHardSql = await GetTempoChart(sequenceAmountInteractions, TypeTransaction.EfCoreAsNoTrackingSqlHard, operationType)
            };

            return result;
        }

        public async Task<IEnumerable<ResultView>> GetResults(OperationType operationType, params int[] sequenceAmountInteractions)
        {
            var results = new List<ResultView>();

            foreach (var inter in sequenceAmountInteractions)
            {
                results.Add(new ResultView
                {
                    Dapper = new ItemResultView
                    {
                        Interactions = inter,
                        Display = await GetTempo(inter, TypeTransaction.Dapper, operationType)
                    },
                    Ef6 = new ItemResultView
                    {
                        Interactions = inter,
                        Display = await GetTempo(inter, TypeTransaction.Ef6, operationType)
                    },
                    EFCore = new ItemResultView
                    {
                        Interactions = inter,
                        Display = await GetTempo(inter, TypeTransaction.EfCore, operationType)
                    },
                    EfCoreAsNoTracking = new ItemResultView
                    {
                        Interactions = inter,
                        Display = await GetTempo(inter, TypeTransaction.EfCoreAsNoTracking, operationType)
                    },
                    EfCoreAsNoTrackingHardSql = new ItemResultView
                    {
                        Interactions = inter,
                        Display = await GetTempo(inter, TypeTransaction.EfCoreAsNoTrackingSqlHard, operationType)
                    },
                });
            }
            return results;
        }

        public async Task<string> GetTempoChart(int[] interactions, TypeTransaction typeTransaction, OperationType operationType)
        {
            var result = await _netcoreContext.Results
                .Where(_ => _.OperationType == operationType && _.TypeTransaction == typeTransaction && interactions.Contains(_.Amount))
                .OrderBy(_ => _.Amount)
                .Select(_ => _.TempoMin.TotalMilliseconds)
                .ToArrayAsync();

            return JsonConvert.SerializeObject(result);
        }

        public async Task<ResultDetailsCell> GetTempo(int amount, TypeTransaction typeTransaction, OperationType operationType)
        {
            var result = await _netcoreContext.Results.FirstOrDefaultAsync(_ =>
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
            if (tempo == null) return result;
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
            return result;
        }

        public string FormatTempoSimplified(TimeSpan? tempo)
        {
            var result = string.Empty;
            if (tempo == null) return result;
            if (tempo?.Minutes != 0)
            {
                result += tempo?.Minutes;
            }
            if (tempo?.Seconds != 0)
            {
                result += "" + tempo?.Seconds;
            }
            if (tempo?.Milliseconds != 0)
            {
                result += "" + tempo?.Milliseconds;
            }
            return result;
        }
    }

}
