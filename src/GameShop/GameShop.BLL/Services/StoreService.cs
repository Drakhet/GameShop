using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameShop.BLL.DTOs;
using GameShop.BLL.Interfaces;
using GameShop.DAL;
using GameShop.DAL.Models;

namespace GameShop.BLL.Services
{
    public class StoreService : IStoreService
    {
        private readonly AppDbContext _context;

        public StoreService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoGameDto>> GetAvailableGamesForUserAsync(int userId)
        {
            var ownedGameIds = await _context.UserGames
                .AsNoTracking()
                .Where(ug => ug.UserId == userId)
                .Select(ug => ug.VideoGameId)
                .ToListAsync();

            var games = await _context.VideoGames
                .AsNoTracking()
                .Where(g => !ownedGameIds.Contains(g.Id))
                .ToListAsync();

            return games.Select(g => new VideoGameDto
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate,
                Description = g.Description,
                CoverImage = g.CoverImage
            }).ToList();
        }

        public async Task<List<VideoGameDto>> GetUserLibraryAsync(int userId)
        {
            var games = await _context.UserGames
                .AsNoTracking()
                .Where(ug => ug.UserId == userId)
                .Include(ug => ug.VideoGame)
                .Select(ug => ug.VideoGame)
                .ToListAsync();

            var validGames = games.Where(g => g != null).ToList();

            return validGames.Select(g => new VideoGameDto
            {
                Id = g!.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate,
                Description = g.Description,
                CoverImage = g.CoverImage
            }).ToList();
        }

        public async Task<bool> PurchaseGameAsync(int userId, int gameId)
        {
            var user = await _context.Users.FindAsync(userId);

            var game = await _context.VideoGames.FindAsync(gameId);

            if (user == null || game == null) return false;

            bool alreadyOwns = await _context.UserGames
                .AsNoTracking() 
                .AnyAsync(ug => ug.UserId == userId && ug.VideoGameId == gameId);

            if (alreadyOwns) return false;

            if (user.Balance < game.Price) return false;

            user.Balance -= game.Price;

            var userGame = new UserGame
            {
                UserId = userId,
                VideoGameId = gameId,
                PurchaseDate = DateTime.Now
            };

            _context.Users.Update(user);
            _context.UserGames.Add(userGame);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AddFundsAsync(int userId, decimal amount)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null && amount > 0)
            {
                user.Balance += amount;
                await _context.SaveChangesAsync();
            }
        }
    }
}