using GameShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.DAL.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.VideoGames.Any())
            {
                context.VideoGames.AddRange(new List<VideoGame>()
                {
                    new VideoGame()
                    {
                        Title = "Minecraft",
                        Description = ".",
                        Genre = "Adventure",
                        Price = 2500,
                        ReleaseDate = new DateTime(2011, 11, 18)
                    },
                    new VideoGame()
                    {
                        Title = "Grand Theft Auto V",
                        Description = "",
                        Genre = "Action",
                        Price = 3500,
                        ReleaseDate = new DateTime(2013, 9, 17)
                    },
                    new VideoGame()
                    {
                        Title = "The Witcher 3",
                        Description = "",
                        Genre = "RPG",
                        Price = 4200,
                        ReleaseDate = new DateTime(2015, 5, 19)
                    },
                    new VideoGame()
                    {
                        Title = "Cyberpunk 2077",
                        Description = "",
                        Genre = "RPG",
                        Price = 3800,
                        ReleaseDate = new DateTime(2020, 12, 10)
                    }
                });
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>()
                {
                    new User()
                    {
                        Username = "admin",
                        Email = "admin@gameshop.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                        Role = "Admin",
                        Balance = 0
                    },

                    new User()
                    {
                        Username = "testuser",
                        Email = "user@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                        Role = "User",
                        Balance = 15000
                    }
                });
                context.SaveChanges();
            }
        }
    }
}