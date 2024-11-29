using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling_lib.Domain.Entities;
[Table("schedules")]
public class Schedule : Entity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("name")]
    public string Name { get; set; }
}