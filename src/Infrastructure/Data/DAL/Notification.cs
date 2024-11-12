using System.ComponentModel.DataAnnotations.Schema;

namespace src.Infrastructure.Data.DAL
{
    [Table("notifications")]
    public class Notification
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("event_id")]
        public int EventId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("sent_at")]
        public DateTime SentAt { get; set; }
    }
}
