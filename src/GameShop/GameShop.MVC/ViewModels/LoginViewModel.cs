using System.ComponentModel.DataAnnotations;

namespace GameShop.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Unesite korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}