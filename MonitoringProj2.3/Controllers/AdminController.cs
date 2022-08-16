using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonitoringProj2._3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Admin controller handles operations associated with the Admin page, such as Activating and Deactivating different sections of the site
/// </summary>
namespace MonitoringProj2._3.Controllers
{
    /// <summary>
    /// The actual Controller class that implements Controller functionality
    /// </summary>
    public class AdminController : Controller
    {
        /// <summary>
        /// Returns the Index view of the Admin page
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")] //Authorize Admin only access to Admin page
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Deactivates the SalesMonitoring page
        /// </summary>
        /// <returns></returns>
        public IActionResult SalesMonDeactivate()
        {
            TempData["SalesMonitoring"] = false;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Activates the SalesMonitoring page
        /// </summary>
        /// <returns></returns>
        public IActionResult SalesMonActivate()
        {
            TempData["SalesMonitoring"] = true;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Deactivates VisitMonitoring page
        /// </summary>
        /// <returns></returns>
        public IActionResult VisitMonitoringDeactivate()
        {
            TempData["VisitMonitoring"] = false;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Activates the VisitMonitoring page
        /// </summary>
        /// <returns></returns>
        public IActionResult VisitMonitoringActivate()
        {
            TempData["VisitMonitoring"] = true;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Deactivates the CartMonitoring page
        /// </summary>
        /// <returns></returns>
        public IActionResult CartMonitoringDeactivate()
        {
            TempData["CartMonitoring"] = false;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Activates the CartMonitoring page
        /// </summary>
        /// <returns></returns>
        public IActionResult CartMonitoringActivate()
        {
            TempData["CartMonitoring"] = true;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Deactivates the ItemStatistics page
        /// </summary>
        /// <returns></returns>
        public IActionResult ItemStatsDeactivate()
        {
            TempData["ItemStats"] = false;
            return RedirectToAction("index");
        }
        /// <summary>
        /// Activates the ItemStatistics page
        /// </summary>
        /// <returns></returns>
        public IActionResult ItemStatsActivate()
        {
            TempData["ItemStats"] = true;
            return RedirectToAction("index");
        }
    }
}