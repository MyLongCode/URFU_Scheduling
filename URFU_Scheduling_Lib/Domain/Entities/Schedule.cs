using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace URFU_Scheduling_lib.Domain.Entities;
[Table("schedules")]
public class Schedule : Entity
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("name")]
    public string Name { get; set; }
    public virtual ICollection<Event> Events { get; }
}