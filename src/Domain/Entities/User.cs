using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Domain.Entities;

[Table("users")]
public class User : Entity
{
    [Column("login")]
    public string Login { get; set; } = null!;

    [Column("password_hash")]
    public string Password { get; set; } = null!;
}
