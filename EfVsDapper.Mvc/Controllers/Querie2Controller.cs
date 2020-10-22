using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfVsDapper.Mvc.Controllers
{
    public class Querie2Controller : Controller
    {
        private readonly DotNetCoreContext _dotNetCoreContext;
        private readonly Ef6Context _ef6Context;
        public Querie2Controller(DotNetCoreContext dotNetCoreContext, Ef6Context ef6Context)
        {
            _dotNetCoreContext = dotNetCoreContext;
            _ef6Context = ef6Context;
        }
        public IActionResult Index(string Sql, string Title)
        {
            return View((Sql, Title));
        }       

        public IActionResult GetCustomersProductsProductPageEfCore()
        {
            var query = _dotNetCoreContext.Customers.Where(c =>
                c.Address.Country == "Brazil" &&
                c.Products.Count() > 50 &&
                c.Products.Any(_ => _.ProductPage.Title.Contains("prod")))
                .Select(_ =>
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

        public IActionResult GetCustomersProductsProductPageEf6()
        {
            var query = _ef6Context.Customers.Where(c =>
                c.Address.Country == "Brazil" &&
                c.Products.Count() > 50 &&
                c.Products.Where(_ => _.ProductPage.Title.Contains("prod")).Count() > 0)
                .Select(_ =>
            new
            {
                Name = _.FirstName,
                _.Address.City,
                TotalPrice =
                _.Products.Sum(p => p.Price)

            });

            var sql = ((dynamic)query).Sql;
            return RedirectToAction("Index", new { Sql = sql, Title = "Ef Core" });
        }
    }
}
