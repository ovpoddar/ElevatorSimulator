using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var totalFloorCount = 5;
            return View(totalFloorCount);
        }
    }
}
