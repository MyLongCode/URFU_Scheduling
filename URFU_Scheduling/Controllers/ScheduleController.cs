using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;
using URFU_Scheduling_lib.Infrastructure.Data;

namespace URFU_Scheduling.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;

        private readonly ScheduleService _scheduleService;
        private readonly EventService _eventService;

        public ScheduleController(
            ILogger<ScheduleController> logger,
            ScheduleService sheduleRepository,
            EventService eventRepository)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
        }

        [HttpPost("/schedule")]
        public async Task<IActionResult> ScheduleCreate(ScheduleDTO dto)
        {
            return Ok(_scheduleService.Create(new Schedule()
            {
                UserId = dto.UserId,
                Name = dto.Name,
            }));
        }

        [HttpGet("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleGetById(Guid scheduleId)
        {
            return Ok(_scheduleService.Get(scheduleId));
        }

        [HttpPut("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleUpdate(Guid scheduleId)
        {
            return Ok();
        }

        [HttpDelete("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleDelete(Guid scheduleId)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound();
            _scheduleService.Delete(schedule);
            return Ok();
        }

        [HttpPost] //what differ with EventController.CreateEvent?
        public async Task<IActionResult> AddEvent(Guid scheduleId)
        {
            return Ok();
        }

        [HttpGet("/schedule/{scheduleId}/events/?period={period}")]
        //help method in eventService
        public async Task<IActionResult> GetEvents(Guid scheduleId, string period)
        {
            return Ok("week or month schedule obj");
        }

        [HttpGet("/schedule/{scheduleId}/export")]
        public async Task<IActionResult> ScheduleExport(Guid scheduleId)
        {
            return Ok("schedule file");
        }

        [HttpPost("schedule/import/?import_type={importType}")]
        public async Task<IActionResult> ScheduleImport(Guid importType)
        {
            return Ok();
        }
    }
}
