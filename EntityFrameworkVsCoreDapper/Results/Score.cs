using System;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class Score : Entity
    {
        public TimeSpan Tempo { get; set; }
        public double Ram { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public int Take { get; set; }
        public TypeObject TypeObject { get; set; }
    }
}
