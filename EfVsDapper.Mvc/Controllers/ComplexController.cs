using EntityFrameworkVsCoreDapper.ConsoleTest;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EfVsDapper.Mvc.Controllers
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

        public IActionResult SelectComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 10000, 100000 };
            return View(_resultService.GetResults(OperationType.SelectComplex, sequenceAmountInteractions));
        }
        public IActionResult InsertComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            var sequenceAmountInteractions = new[] { 1, 5, 50, 200, 1000, 2000, 5000 };
            return View(_resultService.GetResults(OperationType.InsertComplex, sequenceAmountInteractions));
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

        public IActionResult InsertCustomerDapper(int interactions)
        {
            _dapperTests.AjouterCustomersAleatoires(interactions);
            return RedirectToAction("InsertComplex");
        }
        public IActionResult InsertCustomerEf6(int interactions)
        {
            _ef6Tests.AjouterCustomersAleatoires(interactions);
            return RedirectToAction("InsertComplex");
        }
        public IActionResult InsertCustomerEfCore(int interactions)
        {
            _efCoreTests.AjouterCustomersAleatoires(interactions);
            return RedirectToAction("InsertComplex");
        }
        public IActionResult InsertCustomerEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.InsertCustomerSingleAsNotrackingHardSql(interactions);
            return RedirectToAction("InsertComplex");
        }

        public IActionResult Clear(Guid idResult)
        {
            _resultService.ClearResult(idResult);
            return RedirectToAction("SelectComplex");
        }
    }
}