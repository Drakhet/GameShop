using System.ComponentModel.DataAnnotations;

namespace GameShop.MVC.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Morate uneti trenutnu lozinku.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Morate uneti novu lozinku.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Lozinka mora imati bar 6 karaktera.")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Lozinke se ne poklapaju.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}