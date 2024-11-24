using System.ComponentModel.DataAnnotations;

namespace URFU_Scheduling.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [MaxLength(50, ErrorMessage = "Логин не может быть длиннее 50 символов")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [MaxLength(30, ErrorMessage = "Пароль не может быть длиннее 30 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
