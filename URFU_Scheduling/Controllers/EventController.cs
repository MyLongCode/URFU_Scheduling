using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Enums;


namespace URFU_Scheduling.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        private readonly IScheduleService _scheduleService;
        private readonly IEventSerivce _eventService;

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
        public async Task<IActionResult> EventCreate(Guid scheduleId, EventDTO dto)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound("no schedule");
            var newEvent = new Event()
            {
                ScheduleId = dto.ScheduleId,
                TagId = dto.TagId,
                IsNotify = dto.IsNotify,
                Name = dto.Name,
                Description = dto.Description,
                DateStart = dto.DateStart,
                Duration = dto.Duration,
                Recurrence = dto.Recurrence
            };
            return Ok(_eventService.Create(newEvent));
        }

        [HttpGet("/event/{scheduleEventId}")]
        public async Task<IActionResult> EventRetrieve(Guid scheduleEventId)
        {
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");
            return Ok(scheduleEvent);
        }

        [HttpPut("/event/{scheduleEventId}")]
        public async Task<IActionResult> EventUpdate(Guid scheduleEventId, EventDTO dto)
        {
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");

            scheduleEvent.ScheduleId = dto.ScheduleId;
            scheduleEvent.TagId = dto.TagId;
            scheduleEvent.IsNotify = dto.IsNotify;
            scheduleEvent.Name = dto.Name;
            scheduleEvent.Description = dto.Description;
            scheduleEvent.DateStart = dto.DateStart;
            scheduleEvent.Duration = dto.Duration;
            scheduleEvent.Recurrence = dto.Recurrence;
            _eventService.Update(scheduleEvent);

            return Ok(scheduleEvent);
        }

        [HttpDelete("/event/{scheduleEventId}")]
        public async Task<IActionResult> EventDelete(Guid scheduleEventId)
        {
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");
            _eventService.Delete(scheduleEvent);
            return Ok();
        }

        [HttpPost("/event/{scheduleEventId}/addTag/{tagId}")]
        public async Task<IActionResult> AddTag(Guid scheduleEventId, Guid tagId)
        {
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");
            return Ok(_eventService.AddTag(scheduleEventId, tagId));
        }

        [HttpPatch("/event/{scheduleEventId}/recurrence")]
        public async Task<IActionResult> EditEventRepeatability(
            Guid scheduleEventId, RecurrenceEvent eventRecurrence)
        {
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");

            _eventService.EditRepeatability(scheduleEventId, eventRecurrence);
            return Ok(scheduleEvent);
        }

        // сделать, когда будет нужный сервис
        [HttpPost("/event/{scheduleEventId}/import/?import_type={importType}")]
        public async Task<IActionResult> ImportEvent(int scheduleId, int scheduleEventId, string importType)
        {
            return Ok();
        }
    }
}