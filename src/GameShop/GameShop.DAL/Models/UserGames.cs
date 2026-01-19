using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Models
{
    public class UserGame
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int VideoGameId { get; set; }
        [ForeignKey("VideoGameId")]
        public VideoGame? VideoGame { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
