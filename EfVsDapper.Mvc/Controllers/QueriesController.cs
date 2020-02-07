using EfVsDapper.Mvc.Extensions;
using EntityFrameworkVsCoreDapper.EntityFramework;
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

        public IActionResult GetCustomersWhereAddressCountryAndProductsCount()
        {
            var query = _dotNetCoreContext.Customers.Where(c => c.Address.Country == "Brazil" && c.Products.Count() > 50).Select(_ =>
            new { 
                Name = _.FirstName, 
                _.Address.City, TotalPrice = 
                _.Products.Sum(p => p.Price) 
            });
            var result = query.ToSql();
            return RedirectToAction("Index", new { Sql = result, Title = "Ef Core" });
        }

        public IActionResult GetCustomersEf6WhereAddressCountryAndProductsCount()
        {
            var query = _ef6Context.Customers.Where(c => c.Address.Country == "Brazil" && c.Products.Count() > 50).Select(_ =>
            new { Name = _.FirstName, _.Address.City, TotalPrice = _.Products.Sum(p => p.Price) }
            );
            var sql = query.ToString();

            return RedirectToAction("Index", new { Sql = sql, Title = "Ef 6" });
        }
    }
}