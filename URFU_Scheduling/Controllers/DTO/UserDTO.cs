using System.ComponentModel.DataAnnotations.Schema;

namespace URFU_Scheduling.Controllers.DTO;

public class UserDTO
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}
