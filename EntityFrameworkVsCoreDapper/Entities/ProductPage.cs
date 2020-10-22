using EntityFrameworkVsCoreDapper.Entities;

namespace EntityFrameworkVsCoreDapper
{
    public class ProductPage : Entity
    {
        public string Title { get; set; }
        public string SmallDescription { get; set; }
        public string FullDescription { get; set; }
        public string ImageLink { get; set; }
        public ValueChoice Type { get; set; }
    }
}