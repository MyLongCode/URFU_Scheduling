using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Domain.Entities;

public abstract class Entity
{
    [Column("id")]
    public Guid Id { get; set; }
}

