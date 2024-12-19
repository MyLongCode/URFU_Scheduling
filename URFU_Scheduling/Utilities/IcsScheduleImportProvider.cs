using Ical.Net;
using System.Text;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Utilities
{
    public class IcsScheduleImportProvider : IScheduleImportProvider
    {
        public List<Event> Import(byte[] icsBytes)
        {
            var text = ReadIcs(icsBytes);
            var calendar = Calendar.Load(text);
            var events = calendar.Events.Select(x => new Event() {
                DateStart = x.DtStart.Value.ToUniversalTime(),
                Description = x.Description,
                Name = x.Name,
                Duration = x.Duration
            }).ToList();
            return events;
        }

        private static string ReadIcs(byte[] icsBytes)
        {
            using (MemoryStream stream = new MemoryStream(icsBytes))
            using (StreamReader reader = new StreamReader(stream, Encoding.Default, true, 1024, true))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
