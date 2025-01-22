using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace URFU_Scheduling_lib.Domain.Entities
{
    [Table("daily_notifications")]
    public class DailyNotification : Entity
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("sent_at")]
        public DateTime SentAt { get; set; }
    }
}
