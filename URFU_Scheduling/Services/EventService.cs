using Microsoft.EntityFrameworkCore;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Enums;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class EventService : CRUDService<Event>, IEventSerivce
    {
        private readonly EventRepository _eventRepo;
        private readonly ITagService _tagService;
        private readonly IScheduleService _scheduleService;

        public EventService(
        EventRepository eventRepository,
            ITagService tagService) : base(eventRepository)
        {
            _eventRepo = eventRepository;
            _tagService = tagService;
        }

        //monday or 1st day of month
        public Event[] GetEvents(Guid scheduleId, string period, DateTime startDate) 
        {
            switch (period.ToLower())
            {
                case "week":
                    return _eventRepo.GetScheduleEventsByWeek(scheduleId, startDate);
                case "month":
                    return _eventRepo.GetScheduleEventsByMonth(scheduleId, startDate);
                default:
                    throw new ArgumentException("Invalid period specified");
            }
        }

        public Event EditRepeatability(Guid EventId, RecurrenceEvent recurrence)
        {
            var ev = Get(EventId);
            ev.Recurrence = recurrence;
            Update(ev);
            return ev;
        }

        public Event AddTag(Guid eventId, Guid tagId)
        {
            var tag = _tagService.Get(tagId);
            var ev = Get(eventId);
            ev.TagId = eventId;
            Update(ev);
            return ev;
        }
    }
}
