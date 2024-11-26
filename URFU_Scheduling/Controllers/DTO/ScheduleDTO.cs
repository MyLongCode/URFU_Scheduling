using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO
{
    public class ScheduleDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
