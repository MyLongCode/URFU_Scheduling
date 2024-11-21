using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;
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
        public async Task<IActionResult> ScheduleCreate()
        {
            return Ok();
        }

        [HttpGet("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleRetrieve(int scheduleId)
        {
            return Ok("Schedule obj");
        }

        [HttpPut("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleUpdate(int scheduleId)
        {
            return Ok();
        }

        [HttpDelete("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleDelete(int scheduleId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(int scheduleId)
        {
            return Ok();
        }

        [HttpGet("/schedule/{scheduleId}/events/?period={period}")]
        public async Task<IActionResult> GetEvents(int scheduleId, string period)
        {
            return Ok("week or month schedule obj");
        }

        [HttpGet("/schedule/{scheduleId}/export")]
        public async Task<IActionResult> ScheduleExport(int scheduleId)
        {
            return Ok("schedule file");
        }

        [HttpPost("schedule/import/?import_type={importType}")]
        public async Task<IActionResult> ScheduleImport(string importType)
        {
            return Ok();
        }
    }
}
