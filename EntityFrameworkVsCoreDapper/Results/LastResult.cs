using System;

namespace EntityFrameworkVsCoreDapper.Results
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
        public override string ToString()
        {
            return $"Amount: {Amount}, " +
                $"\nTempo( min: {TempoResult.TotalMinutes}, sec: {TempoResult.Seconds}, mils: {TempoResult.Milliseconds}), " +
                $"\nRam: {Ram}, TypeTransaction: {TypeTransaction}, OperationType: {OperationType}";
        }
    }
}
