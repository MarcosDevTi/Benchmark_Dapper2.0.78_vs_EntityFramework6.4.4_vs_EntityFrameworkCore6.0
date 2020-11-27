using EfVsDapper.Mvc.Helpers;
using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        public async Task<IActionResult> SelectComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = await _resultService.CountProducts();
            ViewBag.CountCustomers = await _resultService.CountCustomers();

            return View(await _resultService.GetResults(OperationType.SelectComplex, InteractionsService.SelectComplex));
        }
        public async Task<IActionResult> InsertComplex()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = await _resultService.CountProducts();
            ViewBag.CountCustomers = await _resultService.CountCustomers();

            return View(await _resultService.GetResults(OperationType.InsertComplex, InteractionsService.InsertComplex));
        }

        public async Task<IActionResult> SelectProductDapper(int interactions)
        {
            await _dapperTests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public async Task<IActionResult> SelectProductEf6(int interactions)
        {
            await _ef6Tests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public async Task<IActionResult> SelectProductEfCore(int interactions)
        {
            await _efCoreTests.SelectComplexCustomers(interactions);
            return RedirectToAction("SelectComplex");
        }
        public async Task<IActionResult> SelectProductEfCoreAsNoTracking(int interactions)
        {
            await _efCoreTests.SelectComplexCustomersAsNoTracking(interactions);
            return RedirectToAction("SelectComplex");
        }

        public async Task<IActionResult> InsertCustomerDapper(int interactions)
        {
            await _dapperTests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public async Task<IActionResult> InsertCustomerEf6(int interactions)
        {
            await _ef6Tests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public async Task<IActionResult> InsertCustomerEfCore(int interactions)
        {
            await _efCoreTests.InsertComplexCustomers(interactions);
            return RedirectToAction("InsertComplex");
        }
        public async Task<IActionResult> InsertCustomerEfCoreAsNoTrackingHardSql(int interactions)
        {
            await _efCoreTests.InsertComplexCustomersAsNoTrackingSqlCommand(interactions);
            return RedirectToAction("InsertComplex");
        }

        public async Task<IActionResult> Clear(Guid idResult, string actionRetour)
        {
            await _resultService.ClearResult(idResult);
            return RedirectToAction(actionRetour);
        }
    }
}