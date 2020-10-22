using System.Collections.Generic;

namespace EntityFrameworkVsCoreDapper.Entities
{
    public class ValueDomain : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public IEnumerable<ValueChoice> ValueChoices { get; set; }
    }
}
