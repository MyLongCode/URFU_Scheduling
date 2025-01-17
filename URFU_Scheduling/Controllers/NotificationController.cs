using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Models.ViewModels;
using URFU_Scheduling.Services;
using URFU_Scheduling.Services.Interfaces;


namespace URFU_Scheduling.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;

        private readonly IScheduleService _scheduleService;
        private readonly IEventService _eventService;

        public NotificationController(
            ILogger<NotificationController> logger,
            IScheduleService sheduleRepository,
            IEventService eventRepository)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
        }


        [HttpGet("/notifications")]
        public ActionResult Listen()
        {
            return View();
        }
    }
}