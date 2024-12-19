using System.ComponentModel.DataAnnotations.Schema;


namespace URFU_Scheduling_lib.Domain.Entities
{
    [Table("recurrence")]
    public class Recurrence : Entity 
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("value")]
        public TimeSpan Value { get; set; }
    }
}
