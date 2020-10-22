using EntityFrameworkVsCoreDapper;
using System.Linq;

namespace EfVsDapper.Mvc.Queries
{
    public class CustomersWhereAddressCountryAndProductsCount
    {
        public IQueryable<Customer> Query(IQueryable<Customer> dbSetCustomers)
        {
            return (IQueryable<Customer>)dbSetCustomers.Where(c => c.Address.Country == "Brazil" && c.Products.Count() > 50).Select(_ =>
            new
            {
                Name = _.FirstName,
                _.Address.City,
                TotalPrice =
                _.Products.Sum(p => p.Price)
            });
        }
    }
}
