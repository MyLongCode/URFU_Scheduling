using Microsoft.DotNet.Scaffolding.Shared;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling.Utilities;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class EventService : CRUDService<Event>, IEventService
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

        public Event EditRecurrence(Guid EventId, Guid recurrence)
        {
            var ev = Get(EventId);
            ev.RecurrenceId = recurrence;
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

        public bool Import(IEventImportProvider<Stream> provider, Stream input, out CSVEvent[] result)
        {
            try
            {
                result = provider.Import(input);
                return true;
            }
            catch
            {
                result = default!;
                return false;
            }
        }
    }
}
