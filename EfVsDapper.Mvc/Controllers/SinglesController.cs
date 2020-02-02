using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EfVsDapper.Mvc.Controllers
{
    public class SinglesController : Controller
    {
        private readonly IDapperService _dapperTests;
        private readonly IEf6Service _ef6Tests;
        private readonly IEfCoreService _efCoreTests;
        private readonly ResultService _resultService;
        private readonly MessageService _messageService;
        public SinglesController(
            IDapperService dapperTests,
            IEfCoreService efCoreTests,
            IEf6Service ef6Tests,
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
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 1000, 20000, 1000000 };
            return View(_resultService.GetResults(OperationType.SelectSingle, sequenceAmountInteractions));
        }
        public IActionResult InsertSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 1000, 50000, 1000000 };
            return View(_resultService.GetResults(OperationType.InsertSingle, sequenceAmountInteractions));
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

        public IActionResult InsertProductDapper(int interactions)
        {
            _dapperTests.InsertProductsSingles(interactions);
            return RedirectToAction("InsertSingles");
        }
        public IActionResult InsertProductEf6(int interactions)
        {
            _ef6Tests.InsertProductsSingles(interactions);
            return RedirectToAction("InsertSingles");
        }
        public IActionResult InsertProductEfCore(int interactions)
        {
            _efCoreTests.InsertProductsSingles(interactions);
            return RedirectToAction("InsertSingles");
        }
        public IActionResult InsertProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.InsertProductSingleAsNoTrackingHardSql(interactions);
            return RedirectToAction("InsertSingles");
        }

        public IActionResult Clear(Guid idResult)
        {
            _resultService.ClearResult(idResult);
            return RedirectToAction("SelectSingles");
        }
    }
}