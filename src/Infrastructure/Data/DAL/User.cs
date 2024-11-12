using System.ComponentModel.DataAnnotations.Schema;

namespace src.Infrastructure.Data.DAL
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; } = null!;
        
        [Column("password_hash")]
        public string Password { get; set; } = null!;
    }
}
