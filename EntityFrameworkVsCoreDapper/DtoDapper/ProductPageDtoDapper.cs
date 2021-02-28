using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkVsCoreDapper.DtoDapper
{
    public class ProductPageDtoDapper
    {
        public Guid ProductPageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
