using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;

namespace EfVsDapper.Mvc.Controllers
{
    public class ComplexController : Controller
    {
        private readonly IDapperTests _dapperTests;
        private readonly IEf6Tests _ef6Tests;
        private readonly IEfCoreTests _efCoreTests;
        private readonly ResultService _resultService;
        public ComplexController(
            IDapperTests dapperTests,
            IEfCoreTests efCoreTests,
            IEf6Tests ef6Tests,
            ResultService resultService)
        {
            _dapperTests = dapperTests;
            _efCoreTests = efCoreTests;
            _ef6Tests = ef6Tests;
            _resultService = resultService;
        }
        public IActionResult SelectComplex()
        {
            return View(_resultService.GetResults(OperationType.SelectComplex));
        }
        public IActionResult SelectProductDapper(int interactions)
        {
            _dapperTests.SelectCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public IActionResult SelectProductEf6(int interactions)
        {
            _ef6Tests.SelectCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }

        public IActionResult SelectProductEfCore(int interactions)
        {
            _efCoreTests.SelectCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }

        public IActionResult SelectProductEfCoreAsNoTracking(int interactions)
        {
            _efCoreTests.SelectCustomersAsNoTracking(interactions);
            return RedirectToAction("SelectComplex");
        }
    }
}