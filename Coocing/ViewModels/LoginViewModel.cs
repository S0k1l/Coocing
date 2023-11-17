using System.ComponentModel.DataAnnotations;

namespace Coocing.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name =("Електрона пошта"))]
        public string Email { get; set; }
        [Required]
        [Display(Name = ("Пароль"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
