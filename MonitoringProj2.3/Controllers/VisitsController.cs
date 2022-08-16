using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj2._3.Data;
using MonitoringProj2._3.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VisitsController : Controller
    {

        APIVisitRepository apiVisitRepository = new APIVisitRepository();

        // GET: api/visits
        // Uses APIVisitRepository to create a GET request sent to Azure API, that returns all visits in visits db table
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await apiVisitRepository.ReadAllAsync();
            return View(model);
        }

    }
}
