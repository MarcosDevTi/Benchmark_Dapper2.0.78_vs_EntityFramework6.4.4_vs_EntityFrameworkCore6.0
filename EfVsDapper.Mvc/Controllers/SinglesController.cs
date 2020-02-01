using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;

namespace EfVsDapper.Mvc.Controllers
{
    public class SinglesController : Controller
    {
        private readonly IDapperTests _dapperTests;
        private readonly IEf6Tests _ef6Tests;
        private readonly IEfCoreTests _efCoreTests;
        private readonly ResultService _resultService;
        private readonly MessageService _messageService;
        public SinglesController(
            IDapperTests dapperTests,
            IEfCoreTests efCoreTests,
            IEf6Tests ef6Tests,
            ResultService resultService,
            MessageService messageService)
        {
            _dapperTests = dapperTests;
            _efCoreTests = efCoreTests;
            _ef6Tests = ef6Tests;
            _resultService = resultService;
            _messageService = messageService;
        }
        public IActionResult SelectSingles()
        {
            ViewData["LastResult"] = _messageService.LastResult;
            return View(_resultService.GetResults(OperationType.SelectSingle));
        }
        public IActionResult SelectProductDapper(int interactions)
        {
            _dapperTests.SelectProductsSingles(interactions);
            return RedirectToAction("SelectSingles");
        }
        public IActionResult SelectProductEf6(int interactions)
        {
            _ef6Tests.SelectProductsSingles(interactions);
            return RedirectToAction("SelectSingles");
        }

        public IActionResult SelectProductEfCore(int interactions)
        {
            _efCoreTests.SelectProductsSingles(interactions);
            return RedirectToAction("SelectSingles");
        }

        public IActionResult SelectProductEfCoreAsNoTracking(int interactions)
        {
            _efCoreTests.SelectProductsSinglesAsNoTracking(interactions);
            return RedirectToAction("SelectSingles");
        }

        public IActionResult SelectProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.SelectProductsSinglesAsNoTrackingHardSql(interactions);
            return RedirectToAction("SelectSingles");
        }

        public IActionResult Clear()
        {
            _dapperTests.Clear();
            return RedirectToAction("Index");
        }
    }
}