using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using System.Text;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace URFU_Scheduling.Utilities
{
    public class IcsScheduleExportProvider : IScheduleExportProvider
    {
        public object Export(Schedule schedule)
        {
            var icsCal = new Ical.Net.Calendar();
            var events = schedule.Events.Select(x => new CalendarEvent
            {
                Summary = x.Name,
                Description = x.Description,
                Start = new CalDateTime(x.DateStart),
                Duration = x.Duration
            });

            icsCal.Events.AddRange(events);
            var serializer = new CalendarSerializer();
            var serializedCal = serializer.SerializeToString(icsCal);
            return Encoding.UTF8.GetBytes(serializedCal);

        }
    }
}
