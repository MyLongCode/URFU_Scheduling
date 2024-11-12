using System.ComponentModel.DataAnnotations.Schema;

namespace src.Infrastructure.Data.DAL
{
    [Table("schedules")]
    public class Schedule
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
