using Microsoft.EntityFrameworkCore;
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

        public async Task<List<VideoGame>> GetAllAsync() => await _context.VideoGames.ToListAsync();

        public async Task<VideoGame?> GetByIdAsync(int id) => await _context.VideoGames.FindAsync(id);

        public async Task<VideoGame> CreateAsync(VideoGame game)
        {
            _context.VideoGames.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<VideoGame> UpdateAsync(VideoGame game)
        {
            _context.VideoGames.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null) return false;
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}