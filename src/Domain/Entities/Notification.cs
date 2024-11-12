using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Domain.Entities;


[Table("notifications")]
public class Notification : Entity
{
    [Column("event_id")]
    public int EventId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("message")]
    public string Message { get; set; }

    [Column("sent_at")]
    public DateTime SentAt { get; set; }
}

