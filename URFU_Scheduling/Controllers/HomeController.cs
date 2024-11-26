using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URFU_Scheduling.Models.ViewModels;
using URFU_Scheduling_lib.Infrastructure.Data;
using URFU_Scheduling_lib.Domain.Repositories;
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserRepository _userService;

        public HomeController(
            ILogger<HomeController> logger,
            SchedulingContext db,
            UserRepository userRepository)
        {
            _logger = logger;
            _userService = userRepository;
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
            var first = _userService.GetAll();
            var user = new User(){Login = "admin", Password = "admin"};
            _userService.Add(user);
            var second = _userService.GetAll();
            _userService.Delete(user);
            var third = _userService.GetAll();
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
