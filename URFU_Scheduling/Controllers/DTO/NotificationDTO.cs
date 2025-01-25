using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO
{
    public class NotificationDTO
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}