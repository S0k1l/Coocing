using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Coocing.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = ("Електрона пошта"))]
        public string Email { get; set; }
        [Required]
        [Display(Name = ("І'мя користувача"))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string ConfirmPassword { get; set; }
    }
}
