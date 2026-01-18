using Microsoft.EntityFrameworkCore;
using GameShop.BLL.DTOs;
using GameShop.BLL.Interfaces;
using GameShop.DAL;
using GameShop.DAL.Models;

namespace GameShop.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoGameDto>> GetAllAsync()
        {
            var games = await _context.VideoGames.ToListAsync();
            return games.Select(g => new VideoGameDto
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate,
                Description = g.Description
            }).ToList();
        }

        public async Task<VideoGameDto?> GetByIdAsync(int id)
        {
            var g = await _context.VideoGames.FindAsync(id);
            if (g == null) return null;

            return new VideoGameDto
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate,
                Description = g.Description
            };
        }

        public async Task CreateAsync(VideoGameDto dto)
        {
            var game = new VideoGame
            {
                Title = dto.Title,
                Genre = dto.Genre,
                Price = dto.Price,
                ReleaseDate = dto.ReleaseDate,
                Description = dto.Description
            };
            _context.VideoGames.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VideoGameDto dto)
        {
            var game = await _context.VideoGames.FindAsync(dto.Id);
            if (game != null)
            {
                game.Title = dto.Title;
                game.Genre = dto.Genre;
                game.Price = dto.Price;
                game.ReleaseDate = dto.ReleaseDate;
                game.Description = dto.Description;

                _context.VideoGames.Update(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game != null)
            {
                _context.VideoGames.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}