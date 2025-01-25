using URFU_Scheduling.Utilities;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces;
public interface IEventService : ICRUDSerivce<Event>
{
    public Event[] GetEvents(Guid scheduleId, string period, DateTime startDate);

    public Event EditRecurrence(Guid EventId, Guid recurrenceId);

    public Event AddTag(Guid eventId, Guid tagId);

    public bool Import(IEventImportProvider<Stream> provider, Stream input, out CSVEvent[] result);
}