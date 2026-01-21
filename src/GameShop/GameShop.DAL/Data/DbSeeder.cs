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
                    new VideoGame { Title = "Minecraft", Description = "Explore infinite worlds and build everything from the simplest of homes to the grandest of castles.", Genre = "Adventure", Price = 3000, ReleaseDate = new DateTime(2011, 11, 18), CoverImage = "minecraft.jpg" },
                    new VideoGame { Title = "Grand Theft Auto V", Description = "A young street hustler, a retired bank robber and a terrifying psychopath must pull off a series of dangerous heists.", Genre = "Action", Price = 3000, ReleaseDate = new DateTime(2013, 9, 17), CoverImage = "gtav.jpg" },
                    new VideoGame { Title = "The Witcher 3", Description = "The Witcher: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of choices.", Genre = "RPG", Price = 4000, ReleaseDate = new DateTime(2015, 5, 19), CoverImage = "witcher3.jpg" },
                    new VideoGame { Title = "Cyberpunk 2077", Description = "An open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification.", Genre = "RPG", Price = 6000, ReleaseDate = new DateTime(2020, 12, 10), CoverImage = "cyberpunk.jpg" },
                    new VideoGame { Title = "Arc Raiders", Description = "A cooperative third-person shooter where players defend Earth against an onslaught of robotic threats from space.", Genre = "Action", Price = 4000, ReleaseDate = new DateTime(2025, 1, 1), CoverImage = "arcraiders.jpg" },
                    new VideoGame { Title = "Arknights", Description = "A strategy RPG featuring tower defense mechanics in a dystopian future where you lead operators to fight a deadly infection.", Genre = "Strategy", Price = 0, ReleaseDate = new DateTime(2020, 1, 16), CoverImage = "arknights.jpg" },
                    new VideoGame { Title = "Blasphemous", Description = "A punishing action-platformer that combines fast-paced combat with a deep narrative in the land of Cvstodia.", Genre = "Soulslike", Price = 2500, ReleaseDate = new DateTime(2019, 9, 10), CoverImage = "blasphemous.jpg" },
                    new VideoGame { Title = "Blasphemous 2", Description = "The Penitent One awakens as the struggle against the Miracle continues in a new land full of dangers and secrets.", Genre = "Soulslike", Price = 3000, ReleaseDate = new DateTime(2023, 8, 24), CoverImage = "blasphemous2.jpg" },
                    new VideoGame { Title = "Clair Obscur: Expedition 33", Description = "A reactive turn-based RPG where you lead an expedition to stop the Paintress from erasing humanity.", Genre = "RPG", Price = 5000, ReleaseDate = new DateTime(2025, 3, 1), CoverImage = "expedition33.jpg" },
                    new VideoGame { Title = "Darksiders Warmastered", Description = "Play as War, the first Horseman of the Apocalypse, seeking vengeance against the forces that betrayed him.", Genre = "Action", Price = 2000, ReleaseDate = new DateTime(2010, 1, 5), CoverImage = "darksiders.jpg" },
                    new VideoGame { Title = "Darksiders 2 Deathinitive Edition", Description = "Follow Death, the most feared of the Horsemen, on a quest to redeem his brother's name across vast underworld realms.", Genre = "Action", Price = 3000, ReleaseDate = new DateTime(2012, 8, 14), CoverImage = "darksiders2.jpg" },
                    new VideoGame { Title = "Darksiders 3", Description = "Return to an apocalyptic Earth as Fury, a mage who must hunt down and destroy the Seven Deadly Sins.", Genre = "Action", Price = 4000, ReleaseDate = new DateTime(2018, 11, 27), CoverImage = "darksiders3.jpg" },
                    new VideoGame { Title = "Dark Souls Remastered", Description = "Experience the genre-defining game that started it all, with improved graphics in the land of Lordran.", Genre = "Soulslike", Price = 4000, ReleaseDate = new DateTime(2018, 5, 24), CoverImage = "ds1.jpg" },
                    new VideoGame { Title = "Dark Souls 2: Scholar of the First Sin", Description = "A definitive edition featuring updated enemy placements and all DLC content in the kingdom of Drangleic.", Genre = "Soulslike", Price = 4000, ReleaseDate = new DateTime(2015, 4, 1), CoverImage = "ds2.jpg" },
                    new VideoGame { Title = "Dark Souls 3", Description = "The climactic conclusion to the trilogy, challenging players to survive in a fading world and link the fire.", Genre = "Soulslike", Price = 4000, ReleaseDate = new DateTime(2016, 4, 12), CoverImage = "ds3.jpg" },
                    new VideoGame { Title = "Elden Ring", Description = "Journey through the Lands Between, a vast open world created by Hidetaka Miyazaki and George R. R. Martin.", Genre = "Soulslike", Price = 6000, ReleaseDate = new DateTime(2022, 2, 25), CoverImage = "eldenring.jpg" },
                    new VideoGame { Title = "Hades", Description = "Defy the god of the dead as you hack and slash out of the Underworld in this god-like rogue-lite dungeon crawler.", Genre = "Roguelike", Price = 2500, ReleaseDate = new DateTime(2020, 9, 17), CoverImage = "hades.jpg" },
                    new VideoGame { Title = "Hades 2", Description = "Battle beyond the Underworld using dark sorcery to take on the Titan of Time in this bewitching sequel.", Genre = "Roguelike", Price = 3000, ReleaseDate = new DateTime(2024, 5, 6), CoverImage = "hades2.jpg" },
                    new VideoGame { Title = "Hollow Knight", Description = "Explore a vast, ruined kingdom of insects and heroes in this classically styled 2D action-adventure.", Genre = "Metroidvania", Price = 1500, ReleaseDate = new DateTime(2017, 2, 24), CoverImage = "hollowknight.jpg" },
                    new VideoGame { Title = "Hollow Knight: Silksong", Description = "Play as Hornet, princess-protector of Hallownest, on a journey through a whole new kingdom haunted by silk and song.", Genre = "Metroidvania", Price = 2000, ReleaseDate = new DateTime(2025, 12, 1), CoverImage = "silksong.jpg" },
                    new VideoGame { Title = "Monster Hunter World", Description = "Hunt gigantic monsters in breathtaking landscapes while using the environment and your skills to survive.", Genre = "Action", Price = 3000, ReleaseDate = new DateTime(2018, 1, 26), CoverImage = "mhw.jpg" },
                    new VideoGame { Title = "Monster Hunter Wilds", Description = "The next evolution in the hunting series, featuring dynamic environments and a living ecosystem of monsters.", Genre = "Action", Price = 7000, ReleaseDate = new DateTime(2025, 2, 28), CoverImage = "mhwilds.jpg" },
                    new VideoGame { Title = "Nier: Automata", Description = "A profound story of androids fighting to reclaim a machine-driven dystopia, blending multiple gameplay styles.", Genre = "RPG", Price = 4000, ReleaseDate = new DateTime(2017, 2, 23), CoverImage = "nier.jpg" },
                    new VideoGame { Title = "Kingdoms Of Amalur: Re-Reckoning", Description = "A remastered epic RPG featuring intense customizable combat in a massive world crafted by R.A. Salvatore.", Genre = "RPG", Price = 4000, ReleaseDate = new DateTime(2020, 9, 8), CoverImage = "amalur.jpg" },
                    new VideoGame { Title = "Shape Of Dreams", Description = "A unique action-roguelike that challenges players to navigate through dream worlds and overcome their fears.", Genre = "Roguelike", Price = 2500, ReleaseDate = new DateTime(2024, 10, 1), CoverImage = "shapeofdreams.jpg" }
                });
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>()
                {
                    new User { 
                        Username = "admin",
                        Email = "admin@gameshop.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                        Role = "Admin",
                        Balance = 0 },

                    new User { Username = "testuser",
                        Email = "user@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("1234"),
                        Role = "User",
                        Balance = 15000 }
                });
                context.SaveChanges();
            }
        }
    }
}