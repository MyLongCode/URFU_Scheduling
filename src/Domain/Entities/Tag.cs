using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Domain.Entities;

[Table("tags")]
public class Tag : Entity
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("color")]
    public string Color { get; set; } //ToDo: what type should it be?
}

