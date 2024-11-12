using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URFU_Scheduling.Models;
using URFU_Scheduling.Infrastructure.Data;

namespace URFU_Scheduling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchedulingContext _db;

        public HomeController(ILogger<HomeController> logger, SchedulingContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
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

        [HttpGet]
        [Route("test")]
        public IActionResult DbTest()
        {
            return Ok(_db.Users.ToList());
        }
    }
}
