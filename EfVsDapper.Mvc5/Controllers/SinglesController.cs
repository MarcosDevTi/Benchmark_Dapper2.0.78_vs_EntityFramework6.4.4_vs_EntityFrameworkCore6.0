using EntityFrameworkVsCoreDapperNetFramework.Contracts;
using EntityFrameworkVsCoreDapperNetFramework.Results;
using System;
using System.Web.Mvc;

namespace EfVsDapper.Mvc5.Controllers
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

        public ActionResult SelectSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 1000, 20000, 1000000 };
            return View(_resultService.GetResults(OperationType.SelectSingle, sequenceAmountInteractions));
        }
        public ActionResult InsertSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 1000, 50000, 1000000 };
            return View(_resultService.GetResults(OperationType.InsertSingle, sequenceAmountInteractions));
        }

        public ActionResult SelectProductDapper(int interactions)
        {
            _dapperTests.SelectSingleProducts(interactions);
            return RedirectToAction("SelectSingles");
        }
        public ActionResult SelectProductEf6(int interactions)
        {
            _ef6Tests.SelectSingleProducts(interactions);
            return RedirectToAction("SelectSingles");
        }
        public ActionResult SelectProductEfCore(int interactions)
        {
            _efCoreTests.SelectSingleProducts(interactions);
            return RedirectToAction("SelectSingles");
        }
        public ActionResult SelectProductEfCoreAsNoTracking(int interactions)
        {
            _efCoreTests.SelectSingleProductsAsNoTracking(interactions);
            return RedirectToAction("SelectSingles");
        }
        public ActionResult SelectProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.SelectSingleProductsAsNoTrackingSqlQuery(interactions);
            return RedirectToAction("SelectSingles");
        }

        public ActionResult InsertProductDapper(int interactions)
        {
            _dapperTests.InsertSingleProducts(interactions);
            return RedirectToAction("InsertSingles");
        }
        public ActionResult InsertProductEf6(int interactions)
        {
            _ef6Tests.InsertSingleProducts(interactions);
            return RedirectToAction("InsertSingles");
        }
        public ActionResult InsertProductEfCore(int interactions)
        {
            _efCoreTests.InsertSingleProducts(interactions);
            return RedirectToAction("InsertSingles");
        }
        public ActionResult InsertProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.InsertSingleProductsAsNoTrackingSqlCommand(interactions);
            return RedirectToAction("InsertSingles");
        }

        public ActionResult Clear(Guid idResult)
        {
            _resultService.ClearResult(idResult);
            return RedirectToAction("SelectSingles");
        }
    }
}