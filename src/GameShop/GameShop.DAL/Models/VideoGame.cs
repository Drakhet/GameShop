using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Models
{
    public class VideoGame
    {
        public int Id { get; set; } // Jedinstveni ID
        public string Title { get; set; } // Naslov igre
        public string? Description { get; set; } // Opis
        public string Genre { get; set; } // Žanr
        public decimal Price { get; set; } // Cena
        public DateTime ReleaseDate { get; set; } // Datum izlaska
    }
}
