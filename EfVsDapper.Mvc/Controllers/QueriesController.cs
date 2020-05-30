using EntityFrameworkVsCoreDapper.EntityFramework;
using EntityFrameworkVsCoreDapper.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EfVsDapper.Mvc.Controllers
{
    public class QueriesController : Controller
    {
        private readonly DotNetCoreContext _dotNetCoreContext;
        private readonly Ef6Context _ef6Context;
        public QueriesController(DotNetCoreContext dotNetCoreContext, Ef6Context ef6Context)
        {
            _dotNetCoreContext = dotNetCoreContext;
            _ef6Context = ef6Context;
        }
        public IActionResult Index(string Sql, string Title)
        {
            return View((Sql, Title));
        }

        public IActionResult JoinProductWithCustomersAndAddressIndex(string Sql, string Title)
        {
            return View((Sql, Title));
        }

        public IActionResult GetCustomersWhereAddressCountryAndProductsCount()
        {
            var query = _dotNetCoreContext.Customers.Where(c => c.Address.Country == "Brazil" && c.Products.Count() > 50).Select(_ =>
            new
            {
                Name = _.FirstName,
                _.Address.City,
                TotalPrice =
                _.Products.Sum(p => p.Price)
            });
            var result = query.ToSql();
            return RedirectToAction("Index", new { Sql = result, Title = "Ef Core" });
        }


        public IActionResult GetCustomersEf6WhereAddressCountryAndProductsCount()
        {
            var query = _ef6Context.Customers.Where(c => c.Address.Country == "Brazil" && c.Products.Count() > 50).Select(_ =>
            new
            {
                Name = _.FirstName,
                _.Address.City,
                TotalPrice =
                _.Products.Sum(p => p.Price)
            }
            );
            var sql = query.ToString();
            return RedirectToAction("Index", new { Sql = sql, Title = "Ef 6" });
        }

        public IActionResult JoinProductWithCustomersAndAddressEfCore()
        {
            var query = from p in _dotNetCoreContext.Products
                        join c in _dotNetCoreContext.Customers
                        on p.CustomerId equals c.Id
                        where c.LastName == "LastName test" &&
                        p.Name != "Name product Test" &&
                        c.Address.Street == "Name street test"
                        select new
                        {
                            NameProduct = p.Name,
                            PriceProduct = p.Price,
                            CustomerName = c.FirstName + " " + c.LastName,
                            StreetName = c.Address.Street
                        };
            var result = query.ToSql();
            return RedirectToAction("JoinProductWithCustomersAndAddressIndex", new { Sql = result, Title = "Ef Core" });
        }

        public IActionResult JoinProductWithCustomersAndAddressEf6()
        {
            var query = from p in _ef6Context.Products
                        join c in _ef6Context.Customers
                        on p.CustomerId equals c.Id
                        where c.LastName == "LastName test" &&
                        p.Name != "Name product Test" &&
                        c.Address.Street == "Name street test"
                        select new
                        {
                            NameProduct = p.Name,
                            PriceProduct = p.Price,
                            CustomerName = c.FirstName + " " + c.LastName,
                            StreetName = c.Address.Street
                        };
            var result = query.ToString();
            return RedirectToAction("JoinProductWithCustomersAndAddressIndex", new { Sql = result, Title = "Ef 6" });
        }
    }
}