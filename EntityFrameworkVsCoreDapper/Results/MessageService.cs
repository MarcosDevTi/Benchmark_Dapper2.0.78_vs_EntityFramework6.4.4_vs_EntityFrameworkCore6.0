using System;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class MessageService
    {
        public LastResult LastResult { get; set; }

        public string GetLastResult()
        {
            return LastResult?.ToString();
        }

        public void SetLastResult(int amount, TimeSpan tempoResult, double ram, TypeTransaction typeTransaction, OperationType operationType, double totalRam) =>
            LastResult = new LastResult(amount, tempoResult, ram, typeTransaction, operationType, totalRam);
    }
}
