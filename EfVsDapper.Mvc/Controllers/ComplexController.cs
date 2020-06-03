using EfVsDapper.Mvc.Helpers;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using EntityFrameworkVsCoreDapper.Contracts;

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

            return View(_resultService.GetResults(OperationType.SelectComplex, InteractionsService.SelectComplex));
        }
        public IActionResult InsertComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = _resultService.CountProducts();
            ViewBag.CountCustomers = _resultService.CountCustomers();

            return View(_resultService.GetResults(OperationType.InsertComplex, InteractionsService.InsertComplex));
        }

        public IActionResult SelectProductDapper(int interactions)
        {
            _dapperTests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public IActionResult SelectProductEf6(int interactions)
        {
            _ef6Tests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public IActionResult SelectProductEfCore(int interactions)
        {
            _efCoreTests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public IActionResult SelectProductEfCoreAsNoTracking(int interactions)
        {
            _efCoreTests.SelectComplexCustomersAsNoTracking(interactions);
            return RedirectToAction("SelectComplex");
        }

        public IActionResult InsertCustomerDapper(int interactions)
        {
            _dapperTests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public IActionResult InsertCustomerEf6(int interactions)
        {
            _ef6Tests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public IActionResult InsertCustomerEfCore(int interactions)
        {
            _efCoreTests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public IActionResult InsertCustomerEfCoreAsNoTrackingHardSql(int interactions)
        {
            _efCoreTests.InsertComplexCustomersAsNoTrackingSqlCommand(interactions);
            return RedirectToAction("InsertComplex");
        }

        public IActionResult Clear(Guid idResult, string actionRetour)
        {
            _resultService.ClearResult(idResult);
            return RedirectToAction(actionRetour);
        }
    }
}