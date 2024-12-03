using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO;

public class TagDTO
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}
