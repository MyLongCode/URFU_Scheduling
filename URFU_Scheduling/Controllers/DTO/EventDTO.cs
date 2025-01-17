using System.ComponentModel.DataAnnotations.Schema;
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling.Controllers.DTO
{
    public class EventDTO
    {
        public Guid ScheduleId { get; set; }
        public Guid TagId { get; set; }
        public bool IsNotify { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid RecurrenceId { get; set; }
    }
}