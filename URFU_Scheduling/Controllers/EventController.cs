﻿using Microsoft.AspNetCore.Mvc;
using URFU_Scheduling.Services;
using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.Rendering;
using Humanizer;
using Newtonsoft.Json;
using URFU_Scheduling_lib.Domain.Interfaces;
using Ical.Net;
using System.Data.Entity.Validation;
using URFU_Scheduling.Utilities;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

namespace URFU_Scheduling.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        private readonly IScheduleService _scheduleService;
        private readonly IEventService _eventService;

        private readonly IHubContext<NotificationHub> _hubContext;

        private readonly ITagService _tagService;
        private readonly IUserService _userService;
        private readonly IRecurrenceService _recurrenceService;

        private readonly IEventImportProvider _eventImportProvider;
        public EventController(
            ILogger<EventController> logger,
            IScheduleService sheduleRepository,
            IEventService eventRepository,
            IHubContext<NotificationHub> hubContext,
            ITagService tagService,
            IUserService userService,
            IRecurrenceService recurrenceService,
            IEventImportProvider eventImportProvider)
        {
            _logger = logger;
            _scheduleService = sheduleRepository;
            _eventService = eventRepository;
            _hubContext = hubContext;
            _tagService = tagService;
            _userService = userService;
            _eventImportProvider = eventImportProvider;
            _recurrenceService = recurrenceService;
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
                RecurrenceId = dto.RecurrenceId
            };

            var usr = User.Identity.Name;
            await _hubContext.Clients.All.SendAsync("Receive", usr, $"add event {dto.Name} {dto.DateStart} in schedule {scheduleId}");
            _eventService.Create(newEvent);
            return RedirectToAction("ScheduleGetById", "Schedule", new { scheduleId = dto.ScheduleId, period="week", startDate = DateTime.Now});
        }

        [HttpGet("/event/{scheduleEventId}")]
        public async Task<IActionResult> EventRetrieve(Guid scheduleEventId)
        {
            await _hubContext.Clients.All.SendAsync("Receive", User.Identity.Name, $"view event: {scheduleEventId}");
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");
            var totalString = scheduleEvent.Name + ";" + scheduleEvent.Description + ";" +
                scheduleEvent.DateStart.ToString() + ";" + scheduleEvent.Duration.ToString() + ";" +
                scheduleEvent.Schedule.Name.ToString();
            return Ok(totalString);
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
            scheduleEvent.RecurrenceId = dto.RecurrenceId;
            _eventService.Update(scheduleEvent);

            var totalString = scheduleEvent.Name + " " + scheduleEvent.Description + " " +
                scheduleEvent.DateStart.ToString() + " " + scheduleEvent.Duration.ToString() +
                scheduleEvent.Schedule.Name.ToString();
            return Ok(totalString);
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
            Guid scheduleEventId, Guid recurrenceId)
        {
            var scheduleEvent = _eventService.Get(scheduleEventId);
            if (scheduleEvent == null) return NotFound("no event");

            _eventService.EditRecurrence(scheduleEventId, recurrenceId);
            return Ok(scheduleEvent);
        }

        [HttpPost("/event/{scheduleEventId}/import/{importType}")]
        public async Task<IActionResult> ImportEvent(IFormFile file, Guid scheduleEventId, string importType)
        {
            if (true)
            {
                var stream = file.OpenReadStream();
                var provider = _eventImportProvider as IEventImportProvider<Stream>;
                if (_eventService.Import(provider!, stream, out var result))
                {
                    var defaultRec = _recurrenceService.GetAll().First(e => e.Name == "default");
                    var defaultTag = _tagService.GetAll().First(e => e.Name == "default");
                    foreach (var csvEvent in result)
                    {
                        var e = new Event
                        {
                            ScheduleId = scheduleEventId,
                            Name = csvEvent.Name,
                            Description = csvEvent.Description,
                            Duration = csvEvent.Duration,
                            DateStart = csvEvent.DateStart,
                            TagId = defaultTag.Id,
                            RecurrenceId = defaultRec.Id,
                        };
                        _eventService.Create(e);
                    }
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}