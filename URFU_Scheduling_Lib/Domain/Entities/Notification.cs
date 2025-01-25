﻿using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling_lib.Domain.Entities;


[Table("notifications")]
public class Notification : Entity
{
    [Column("event_id")]
    public Guid EventId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("message")]
    public string Message { get; set; }

    [Column("sent_at")]
    public DateTime SentAt { get; set; }
}

