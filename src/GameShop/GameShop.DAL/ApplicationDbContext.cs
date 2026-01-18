using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GameShop.DAL.Models;

namespace GameShop.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<User> Users { get; set; }
    }
    }
}

