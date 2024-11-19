using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URFU_Scheduling.Models;
using URFU_Scheduling.Infrastructure.Data;
using URFU_Scheduling.Domain.Repositories;
using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserRepository _userRepo;

        public HomeController(
            ILogger<HomeController> logger,
            SchedulingContext db,
            UserRepository userRepository)
        {
            _logger = logger;
            _userRepo = userRepository;
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
            var first = _userRepo.GetAll();
            var user = new User(){Login = "admin", Password = "admin"};
            _userRepo.Add(user);
            var second = _userRepo.GetAll();
            _userRepo.Delete(user);
            var third = _userRepo.GetAll();
            return Ok(
                new Dictionary<string, object>()
                {
                    {"first", first},
                    {"second", second},
                    {"third", third}
                });
        }
    }
}
