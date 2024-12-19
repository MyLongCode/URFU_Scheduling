using System.Drawing;

namespace URFU_Scheduling.Controllers.DTO;

public class TagDTO
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public Color Color { get; set; }
}
