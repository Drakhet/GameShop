using System.ComponentModel.DataAnnotations;

namespace GameShop.MVC.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Korisničko ime mora imati između 3 i 20 karaktera.")]
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email adresa je obavezna.")]
        [EmailAddress(ErrorMessage = "Neispravan format email adrese.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Lozinka mora imati najmanje 4 karaktera.")]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Morate dodeliti ulogu.")]
        [Display(Name = "Uloga")]
        public string Role { get; set; }
    }
}