using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string? Description { get; set; } 
        public string Genre { get; set; } 
        public decimal Price { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public string CoverImage { get; set; }
    }
}
