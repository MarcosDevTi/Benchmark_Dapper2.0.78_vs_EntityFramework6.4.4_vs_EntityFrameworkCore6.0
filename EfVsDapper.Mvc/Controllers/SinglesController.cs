using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EfVsDapper.Mvc.Controllers
{
    public class SinglesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}