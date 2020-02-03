using System;

namespace EntityFrameworkVsCoreDapperNetFramework.Results
{
    public class LastResult
    {
        public LastResult(int amount, TimeSpan tempoResult, double ram, TypeTransaction typeTransaction, OperationType operationType, double totalRam)
        {
            Amount = amount;
            TempoResult = tempoResult;
            Ram = ram;
            TypeTransaction = typeTransaction;
            OperationType = operationType;
            TotalRam = totalRam;
        }
        public int Amount { get; set; }
        public TimeSpan TempoResult { get; set; }
        public double Ram { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public OperationType OperationType { get; set; }
        public double TotalRam { get; set; }
    }
}
