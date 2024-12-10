using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Enums;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces;
public interface IEventService : ICRUDSerivce<Event>
{
    public Event[] GetEvents(Guid scheduleId, string period, DateTime startDate);

    public Event EditRepeatability(Guid EventId, RecurrenceEvent recurrence);

    public Event AddTag(Guid eventId, Guid tagId);

}