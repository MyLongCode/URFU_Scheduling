using System.ComponentModel.DataAnnotations.Schema;
using URFU_Scheduling_lib.Domain.Enums;

namespace URFU_Scheduling_lib.Domain.Entities;

[Table("events")]
public class Event : Entity
{
    [Column("schedule_id")]
    public Guid ScheduleId { get; set; }

    [Column("tag_id")]
    public Guid? TagId { get; set; }

    [Column("is_notify")]
    public bool IsNotify { get; set; }

    [Column("name")]
    public string Name{ get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("date_start")]
    public DateTime DateStart { get; set; }

    [Column("duration")]
    public TimeSpan Duration { get; set; }

    [Column("recurrence")]
    public RecurrenceEvent Recurrence { get; set; }
}
