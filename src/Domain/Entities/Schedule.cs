using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Domain.Entities;
[Table("schedules")]
public class Schedule : Entity
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("name")]
    public string Name { get; set; }
}