using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using System;

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

        public IActionResult Clear(Guid idResult)
        {
            _resultService.ClearResult(idResult);
            return RedirectToAction("SelectSingles");
        }
        public IActionResult SelectSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 10000, 200000, 2000000 };
            return View(_resultService.GetResults(OperationType.SelectSingle, sequenceAmountInteractions));
        }

        public IActionResult InsertSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 10000, 200000, 2000000 };
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

        public IActionResult InsertProductEfCoreAsNoTracking(int interactions)
        {
            _efCoreTests.InsertProductsSinglesAsNoTracking(interactions);
            return RedirectToAction("InsertSingles");
        }

        public IActionResult InsertProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.InsertProductSingleAsNoTrackingHardSql(interactions);
            return RedirectToAction("InsertSingles");
        }
    }
}