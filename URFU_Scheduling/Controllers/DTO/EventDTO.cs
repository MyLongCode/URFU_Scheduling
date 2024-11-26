using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO
{
    public class EventDTO
    {
        public int ScheduleId { get; set; }
        public int TagId { get; set; }
        public bool IsNotify { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan Recurrence { get; set; }
    }
}
