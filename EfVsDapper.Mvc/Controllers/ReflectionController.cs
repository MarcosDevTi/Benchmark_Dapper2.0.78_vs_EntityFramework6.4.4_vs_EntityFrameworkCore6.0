using EntityFrameworkVsCoreDapper.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EfVsDapper.Mvc.Controllers
{
    public class ReflectionController : Controller
    {
        private readonly ReflectionService _reclectionService;
        public ReflectionController(ReflectionService reclectionService)
        {
            _reclectionService = reclectionService;
        }

        public IActionResult Index()
        {
            return View(_reclectionService.ReflectionResult);
        }

        public IActionResult CreateListNormaly(int iterations)
        {
            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++)
            {
                var list = new List<int>();
            }
            var endTime = DateTimeOffset.Now;

            _reclectionService.ReflectionResult.ListWithoutReflection = GetDurationString(startTime, endTime);
            return RedirectToAction("Index");
        }

        public IActionResult CreateListReflection(int iterations)
        {

            Type listType = typeof(List<int>);

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++)
            {
                var list = Activator.CreateInstance(listType);
            }
            var endTime = DateTimeOffset.Now;

            _reclectionService.ReflectionResult.ListReflection = GetDurationString(startTime, endTime);

            return RedirectToAction("Index");
        }

        public IActionResult StaticMethod(int iterations)
        {

            var list = new List<int>();

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++)
            {
                list.Add(i);
            }
            var endTime = DateTimeOffset.Now;

            _reclectionService.ReflectionResult.StaticMethod = GetDurationString(startTime, endTime);

            return RedirectToAction("Index");
        }

        public IActionResult ReflectionMethod(int iterations)
        {

            var list = new List<int>();

            Type listType = typeof(List<int>);
            Type[] parameterTypes = { typeof(int) };
            MethodInfo mi = listType.GetMethod("Add", parameterTypes);

            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++)
            {
                mi.Invoke(list, new object[] { i });
            }
            var endTime = DateTimeOffset.Now;

            _reclectionService.ReflectionResult.ReflectionMethod = GetDurationString(startTime, endTime);

            return RedirectToAction("Index");
        }

        private string GetDurationString(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            var duration = endTime - startTime;
            return string.Format("{0:F0} ms", duration.TotalMilliseconds);
        }
    }
}
