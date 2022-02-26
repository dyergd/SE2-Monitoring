using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MonitoringProj2._3.Controllers
{
    public class TacoController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View((object)"Hello");
        }
    }
}
