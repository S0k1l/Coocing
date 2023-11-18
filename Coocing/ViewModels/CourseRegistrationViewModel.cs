using System.ComponentModel.DataAnnotations;

namespace Coocing.ViewModels
{
    public class CourseRegistrationViewModel
    {
        [Display(Name ="ПІБ")]
        public string FullName { get; set; }
        [MaxLength(9)]
        [MinLength(9)]
        [Display(Name = "Номер телефон")]
        public string PhoneNumber  { get; set; }
    }
}
