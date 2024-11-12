using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace src.Infrastructure.Data.DAL
{
    [Table("tags")]
    public class Tag
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("color")]
        public string Color { get; set; } //ToDo: what type should it be?
    }
}
