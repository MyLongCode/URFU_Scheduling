using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;

namespace URFU_Scheduling.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        private readonly ScheduleService _scheduleService;
        private readonly EventService _eventService;

        public EventController(
            ILogger<EventController> logger,
            ScheduleService sheduleRepository,
            EventService eventRepository)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
        }
        [HttpPost("/schedule/{scheduleId}/event")]
        public async Task<IActionResult> EventCreate(int scheduleId)
        {
            return Ok();
        }

        [HttpGet("/schedule/{scheduleId}/event/{scheduleEventId}")]
        public async Task<IActionResult> EventRetrieve(int scheduleId, int scheduleEventId)
        {
            return Ok("ScheduleEvent obj");
        }

        [HttpPut("/schedule/{scheduleId}/event/{scheduleEventId}")]
        public async Task<IActionResult> EventUpdate(int scheduleId, int scheduleEventId)
        {
            return Ok();
        }

        [HttpDelete("/schedule/{scheduleId}/event/{scheduleEventId}")]
        public async Task<IActionResult> EventDelete(int scheduleId, int scheduleEventId)
        {
            return Ok();
        }

        [HttpPost("/schedule/{scheduleId}/event/{scheduleEventId}/addTag/{tagId}")]
        public async Task<IActionResult> AddTag(int scheduleId, int scheduleEventId, int tagId)
        {

            return Ok();
        }

        [HttpPatch("/schedule/{scheduleId}/event/{scheduleEventId}/recurrence")]
        public async Task<IActionResult> EditEventRepeatability(int scheduleId, int scheduleEventId)
        {

            return Ok();
        }

        [HttpPost("/schedule/{scheduleId}/event/{scheduleEventId}/import/?import_type={importType}")]
        public async Task<IActionResult> ImportEvent(int scheduleId, int scheduleEventId, string importType)
        {

            return Ok();
        }
    }
}
