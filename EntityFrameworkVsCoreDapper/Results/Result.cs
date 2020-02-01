using System;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class Result : Entity
    {
        public TypeTransaction TypeTransaction { get; set; }
        public OperationType OperationType { get; set; }
        public int Amount { get; set; }
        public TimeSpan TempoMin { get; set; }
        public TimeSpan TempoMax { get; set; }
        public double RamMin { get; set; }
        public double RamMax { get; set; }
    }

    public class ResultInput
    {
        public TypeTransaction TypeTransaction { get; set; }
        public OperationType OperationType { get; set; }
        public int Amount { get; set; }
        public TimeSpan Tempo { get; set; }
        public double Ram { get; set; }
    }
}
