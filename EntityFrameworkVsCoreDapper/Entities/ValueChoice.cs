namespace EntityFrameworkVsCoreDapper.Entities
{
    public class ValueChoice : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int OrderPresentation { get; set; }
    }
}
