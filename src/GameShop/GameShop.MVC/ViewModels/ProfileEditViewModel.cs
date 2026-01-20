using System.ComponentModel.DataAnnotations;

namespace GameShop.MVC.ViewModels
{
    public class ProfileEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage = "Neispravan email format")]
        public string Email { get; set; }

        [Display(Name = "Nova profilna slika")]
        public IFormFile? ImageUpload { get; set; }

        public bool HasProfilePicture { get; set; }
    }
}