using System;
using System.Collections.Generic;

namespace EntityFrameworkVsCoreDapper.Results
{
    public class Result : Entity
    {
        public DateTime Date { get; set; }
        public ICollection<ResultItem> ResultItems { get; set; }
    }
}
