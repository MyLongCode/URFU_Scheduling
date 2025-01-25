using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace URFU_Scheduling_lib.Domain.Entities;

[Table("tags")]
public class Tag : Entity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("color")]
    public Color Color { get; set; }
}

