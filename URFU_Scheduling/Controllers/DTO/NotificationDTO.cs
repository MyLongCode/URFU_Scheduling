using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO
{
    public class NotificationDTO
    {
        public int EventId { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}