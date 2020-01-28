using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.Context;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;

namespace EfVsDapper.Mvc.Controllers
{
    public class SinglesController : Controller
    {
        private readonly IDapperTests _dapperTests;
        private readonly DapperContext _dapperContext;
        public SinglesController(IDapperTests dapperTests, DapperContext dapperContext)
        {
            _dapperTests = dapperTests;
            _dapperContext = dapperContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TesteSingleList(int interactions, TypeTransaction typeTransaction)
        {
            _dapperTests.SelectProductsSingles(interactions);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _dapperTests.Clear();
            return RedirectToAction("Index");
        }
    }
}