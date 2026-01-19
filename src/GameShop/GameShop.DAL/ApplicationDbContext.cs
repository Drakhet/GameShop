using Microsoft.EntityFrameworkCore;
using GameShop.DAL.Models;

namespace GameShop.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGame> UserGames{ get; set; }
    }
}