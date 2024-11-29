using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO
{
    public class ScheduleDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
