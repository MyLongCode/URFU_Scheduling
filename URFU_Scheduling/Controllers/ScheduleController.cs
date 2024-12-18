using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Interfaces;


namespace URFU_Scheduling.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IScheduleService _scheduleService;
        private readonly IEventService _eventService;
        private readonly IScheduleExportProvider _exportProvider;
        private readonly IScheduleImportProvider _importProvider;



        public ScheduleController(
            ILogger<ScheduleController> logger,
            IScheduleService sheduleRepository,
            IEventService eventRepository,
            IScheduleExportProvider exportProvider,
            IScheduleImportProvider importProvider)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
            _exportProvider = exportProvider;
            _importProvider = importProvider;
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

        [HttpGet("/schedule/{scheduleId}/events/{period}")]
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
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NoContent();
            _scheduleService.Export(_exportProvider, schedule, out object result);
            var data = result as byte[];
            //return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            return File(data, "text/calendar", $"{schedule.Name}.ics");
        }

        [HttpPost("/schedule/import/{userId}")]
        public async Task<IActionResult> ScheduleImport(Guid userId, IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("Файл не загружен.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();
                if (_scheduleService.Import(_importProvider, bytes, out object result))
                {
                    var events = result as List<Event>;
                    var schedule = new Schedule()
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        Name = "Imported"
                    };

                    _scheduleService.Create(schedule);

                    foreach(var el in events)
                    {
                        el.ScheduleId = schedule.Id;
                        _eventService.Create(el);
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest("Ошибка при импорте расписания.");
                }

            }
        }
    }
}