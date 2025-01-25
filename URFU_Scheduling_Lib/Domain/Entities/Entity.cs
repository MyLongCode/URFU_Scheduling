using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling_lib.Domain.Entities;

public abstract class Entity
{
    [Column("id")]
    public Guid Id { get; set; }
}

