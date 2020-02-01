using System;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class Result : Entity
    {
        public string Name { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public OperationType OperationType { get; set; }
        public int Amount { get; set; }
        public TimeSpan Tempo { get; set; }
        public double Ram { get; set; }
    }
}
