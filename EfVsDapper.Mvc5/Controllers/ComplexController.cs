using EntityFrameworkVsCoreDapperNetFramework.Contracts;
using EntityFrameworkVsCoreDapperNetFramework.Results;
using System;
using System.Web.Mvc;

namespace EfVsDapper.Mvc5.Controllers
{
    public class ComplexController : Controller
    {
        private readonly IDapperService _dapperTests;
        private readonly IEf6Service _ef6Tests;
        private readonly IEfCoreService _efCoreTests;
        private readonly ResultService _resultService;
        private readonly MessageService _messageService;
        public ComplexController(
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

        public ActionResult SelectComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 10000, 100000 };
            return View(_resultService.GetResults(OperationType.SelectComplex, sequenceAmountInteractions));
        }
        public ActionResult InsertComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 1000, 2000, 5000 };
            return View(_resultService.GetResults(OperationType.InsertComplex, sequenceAmountInteractions));
        }

        public ActionResult SelectProductDapper(int interactions)
        {
            _dapperTests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public ActionResult SelectProductEf6(int interactions)
        {
            _ef6Tests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public ActionResult SelectProductEfCore(int interactions)
        {
            _efCoreTests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public ActionResult SelectProductEfCoreAsNoTracking(int interactions)
        {
            _efCoreTests.SelectComplexCustomersAsNoTracking(interactions);
            return RedirectToAction("SelectComplex");
        }

        public ActionResult InsertCustomerDapper(int interactions)
        {
            _dapperTests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public ActionResult InsertCustomerEf6(int interactions)
        {
            _ef6Tests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public ActionResult InsertCustomerEfCore(int interactions)
        {
            _efCoreTests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public ActionResult InsertCustomerEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.InsertComplexCustomersAsNoTrackingSqlCommand(interactions);
            return RedirectToAction("InsertComplex");
        }

        public ActionResult Clear(Guid idResult)
        {
            _resultService.ClearResult(idResult);
            return RedirectToAction("SelectComplex");
        }
    }
}