using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonitoringProj2._3.Models;
using MonitoringProj2._3.Models.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MonitoringProj2._3.Services;

namespace MonitoringProj2._3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("Start1"))
            {
                return View();
            }
            else
            {
                TempData["Start1"] = true;
                TempData["SalesMonitoring"] = true;
                TempData["ItemStats"] = true;
                TempData["CartMonitoring"] = true;
                TempData["VisitMonitoring"] = true;
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
