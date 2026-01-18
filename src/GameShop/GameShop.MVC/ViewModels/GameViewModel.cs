using System.ComponentModel.DataAnnotations;

namespace GameShop.MVC.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naslov je obavezan.")]
        [Display(Name = "Naslov Igre")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Žanr je obavezan.")]
        [Display(Name = "Kategorija")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Cena je obavezna.")]
        [Range(1, 80, ErrorMessage = "Cena mora biti između 1 i 80$.")]
        [Display(Name = "Cena (RSD)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Datum izlaska je obavezan.")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum izlaska")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}