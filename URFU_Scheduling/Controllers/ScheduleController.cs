using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling.Services;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace URFU_Scheduling.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IScheduleService _scheduleService;
        private readonly IEventService _eventService;
        private readonly IScheduleExportProvider _exportProvider;
        private readonly IUserService _userService;

        public ScheduleController(
            ILogger<ScheduleController> logger,
            IScheduleService sheduleRepository,
            IEventService eventRepository,
            IScheduleExportProvider exportProvider,
            IUserService userService)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
            _exportProvider = exportProvider;
            _userService = userService;
        }

        [HttpGet("/schedule")]
        public async Task<IActionResult> ScheduleCreate()
        {
            var viewmodel = new CreateScheduleViewModel()
            {
                UserId = _userService.GetIdByLogin(User.Identity.Name)
            };
            return View(viewmodel);
        }

        [HttpPost("/schedule")]
        public async Task<IActionResult> ScheduleCreate(ScheduleDTO dto)
        {
            _scheduleService.Create(new Schedule()
            {
                UserId = dto.UserId,
                Name = dto.Name,
            });
            return RedirectToAction("ScheduleGetByUserId");
        }

        [HttpGet("/schedule/all")]
        public async Task<IActionResult> ScheduleGetByUserId()
        {
            var userId = _userService.GetIdByLogin(User.Identity.Name);
            var schedules = _scheduleService.GetAllUserSchedules(userId);
            var viewmodel = new ListSchedulesViewModel()
            {
                Schedules = schedules
            };
            return View("ListSchedules", viewmodel);
        }

        [HttpGet("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleGetById(Guid scheduleId, string period, DateTime startDate)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound("schedule is not defined");
            if (period == null) period = "week";
            if (startDate == null) startDate = DateTime.MinValue;
            var events = _eventService.GetEvents(schedule.Id, period, startDate).ToList();
            var viewmodel = new ScheduleViewModel()
            {
                Id = scheduleId,
                ScheduleName = schedule.Name,
                Events = events,
                Period = period,
            };
            return View("Index", viewmodel);
            //return schedule != null ? Ok(schedule) : NotFound("no schedule");
        }

        [HttpPut("/schedule/{scheduleId}")]
        public async Task<IActionResult> ScheduleUpdate(Guid scheduleId, ScheduleDTO dto)
        {
            var schedule = _scheduleService.Get(scheduleId);
            if (schedule == null) return NotFound("no schedule");
            schedule.Name = dto.Name;
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
            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [HttpPost("schedule/import/{importType}")]
        public async Task<IActionResult> ScheduleImport(Guid importType)
        {
            return Ok();
        }
    }
}