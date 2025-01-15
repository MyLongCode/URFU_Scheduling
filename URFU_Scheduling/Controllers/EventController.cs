﻿using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace URFU_Scheduling.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        private readonly IScheduleService _scheduleService;
        private readonly IEventService _eventService;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public EventController(
            ILogger<EventController> logger,
            IScheduleService sheduleRepository,
            IEventService eventRepository,
            ITagService tagService,
            IUserService userService)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
            _tagService = tagService;
            _userService = userService;
        }

        [HttpGet("/schedule/{scheduleId}/event")]
        public async Task<IActionResult> EventCreate(Guid scheduleId)
        {
            var schedule = _scheduleService.Get(scheduleId);
            var userTags = _tagService.GetUserTags(_userService.GetIdByLogin(User.Identity.Name));
            var viewmodel = new EventDTO()
            {
                ScheduleId = scheduleId,
                DateStart = DateTime.Now
            };
            ViewBag.Tags = userTags.Select(tag => new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.Name
            }).ToList();
            return View(viewmodel);
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
            _eventService.Create(newEvent);
            return RedirectToAction("ScheduleGetById", "Schedule", new { scheduleId = dto.ScheduleId, period="week", startDate = DateTime.Now});
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

        [HttpPost("/event/{scheduleEventId}/import/{importType}")]
        public async Task<IActionResult> ImportEvent(int scheduleId, int scheduleEventId, string importType)
        {
            return Ok();
        }
    }
}