using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public Guid Id { get; set; }
        public string ScheduleName { get; set; }
        public List<Event> Events { get; set; }
        public string Period { get; set; }
    }
}
