using EntityFrameworkVsCoreDapper.Results;

namespace EntityFrameworkVsCoreDapper.Helpers
{
    public class ReflectionService
    {
        public ReflectionService()
        {
            ReflectionResult = new ReflectionResult();
        }
        public ReflectionResult ReflectionResult { get; set; }
    }
}
