using System.ComponentModel.DataAnnotations;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Models.ViewModels
{
    public class RegistrationViewModel : IRegistrationData
    {
        [Required(ErrorMessage = "Не указан логин")]
        [MaxLength(50, ErrorMessage = "Логин не может быть длиннее 50 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "Пароль не может быть длиннее 30 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "Пароль не может быть длиннее 30 символов")]
        public string ConfirmPassword { get; set; }
    }
}
