using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;

namespace URFU_Scheduling.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;

        private readonly IScheduleService _scheduleService;
        private readonly IEventSerivce _eventService;

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
            var schedule = _scheduleService.Get(scheduleId);
            return schedule != null ? Ok(schedule) : NotFound("no schedule");
        }

        [HttpPut("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleUpdate(Guid scheduleId, ScheduleDTO dto)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound("no schedule");
            schedule.Name = dto.Name;
            // ��� �������, ��� schedule.UserId = dto.UserId; �� �����, ��������
            // ������������ ����� ���������� ���� ����������??
            _scheduleService.Update(schedule);
            return Ok(schedule);
        }

        [HttpDelete("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleDelete(Guid scheduleId)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound("no schedule");
            _scheduleService.Delete(schedule);
            return Ok();
        }

        [HttpGet("/schedule/{scheduleId}/events/?period={period}")]
        //help method in eventService
        // NEW 
        // �������� ��� ����� ���������� ������������� ������, ���� ������� ������� � ���������� ����� �����,
        // ��� �� ����� ����� ������ ������? � ����� ����� �� ����� ������������: �����, �������, ���?
        // + �� ��� ������ ���� � ����������, �� ���� ����� ����� ���������� ���������� �� ������� ������ � � �������
        public async Task<IActionResult> GetEvents(Guid scheduleId, string period, DateTime dateStart)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound("no schedule");
            return Ok(_eventService.GetEvents(scheduleId, period, dateStart));
        }

        [HttpGet("/schedule/{scheduleId}/export")]
        public async Task<IActionResult> ScheduleExport(Guid scheduleId)
        {
            // �������, ����� ����� ����� ScheduleExport
            return Ok("schedule file");
        }

        [HttpPost("schedule/import/?import_type={importType}")]
        public async Task<IActionResult> ScheduleImport(Guid importType)
        {
            // �������, ����� ����� ����� ScheduleImport
            return Ok();
        }
    }
}