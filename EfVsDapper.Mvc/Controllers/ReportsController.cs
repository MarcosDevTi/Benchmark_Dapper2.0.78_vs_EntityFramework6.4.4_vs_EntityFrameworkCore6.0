using EntityFrameworkVsCoreDapper.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EfVsDapper.Mvc.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ResultService _resultService;
        public ReportsController(ResultService resultService)
        {
            _resultService = resultService;
        }
        public IActionResult Index(OperationType operationType, string interactions)
        {
            ViewBag.Interactions = interactions;
            ViewBag.OperationType = operationType.ToString();
            return View(_resultService.GetResultsChart(operationType, JsonConvert.DeserializeObject<int[]>(interactions)));
        }
    }
}