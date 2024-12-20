using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services.Interfaces;

namespace URFU_Scheduling.Controllers
{
    [Authorize]
    [Route("/profile")]
    public class ProfileController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly IEventService _eventService;
        
        public ProfileController(IScheduleService scheduleService, IEventService eventService)
        {
            _scheduleService = scheduleService;
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
