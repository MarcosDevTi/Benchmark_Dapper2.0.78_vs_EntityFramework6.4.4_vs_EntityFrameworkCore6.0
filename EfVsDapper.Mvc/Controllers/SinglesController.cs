using EfVsDapper.Mvc.Helpers;
using EntityFrameworkVsCoreDapper.Contracts;
using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        public async Task<IActionResult> SelectSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = await _resultService.CountProducts();
            ViewBag.CountCustomers = await _resultService.CountCustomers();

            return View(await _resultService.GetResults(OperationType.SelectSingle, InteractionsService.SelectSingle));
        }
        public async Task<IActionResult> InsertSingles()
        {
            ViewBag.LastResult = _messageService.LastResult;
            ViewBag.CountProducts = await _resultService.CountProducts();
            ViewBag.CountCustomers = await _resultService.CountCustomers();

            return View(await _resultService.GetResults(OperationType.InsertSingle, InteractionsService.InsertSingle));
        }

        public async Task<IActionResult> SelectProductDapper(int interactions)
        {
            await _dapperTests.SelectSingleProducts(interactions);
            return RedirectToAction("SelectSingles");
        }
        public async Task<IActionResult> SelectProductEf6(int interactions)
        {
            await _ef6Tests.SelectSingleProducts(interactions);
            return RedirectToAction("SelectSingles");
        }
        public async Task<IActionResult> SelectProductEfCore(int interactions)
        {
            await _efCoreTests.SelectSingleProducts(interactions);
            return RedirectToAction("SelectSingles");
        }
        public async Task<IActionResult> SelectProductEfCoreAsNoTracking(int interactions)
        {
            await _efCoreTests.SelectSingleProductsAsNoTracking(interactions);
            return RedirectToAction("SelectSingles");
        }
        public async Task<IActionResult> SelectProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            await _efCoreTests.SelectSingleProductsAsNoTrackingSqlQuery(interactions);
            return RedirectToAction("SelectSingles");
        }

        public async Task<IActionResult> InsertProductDapper(int interactions)
        {
            await _dapperTests.InsertSingleProducts(interactions);
            return RedirectToAction("InsertSingles");
        }
        public async Task<IActionResult> InsertProductEf6(int interactions)
        {
            await _ef6Tests.InsertSingleProducts(interactions);
            return RedirectToAction("InsertSingles");
        }
        public async Task<IActionResult> InsertProductEfCore(int interactions)
        {
            await _efCoreTests.InsertSingleProducts(interactions);
            return RedirectToAction("InsertSingles");
        }
        public async Task<IActionResult> InsertProductEfCoreAsNoTrackingHardSql(int interactions)
        {
            await _efCoreTests.InsertSingleProductsAsNoTrackingSqlCommand(interactions);
            return RedirectToAction("InsertSingles");
        }

        public async Task<IActionResult> Clear(Guid idResult, string ActionRetour)
        {
            await _resultService.ClearResult(idResult);
            return RedirectToAction(ActionRetour);
        }
    }
}