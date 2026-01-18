using GameShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class GameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public List<VideoGame> GetAll()
        {
            return _context.VideoGames.ToList();
        }

        
        public VideoGame GetById(int id)
        {
            return _context.VideoGames.FirstOrDefault(g => g.Id == id);
        }

        // Dodaje novu igru (note to self implement samo admin da ima access)
        public void Add(VideoGame game)
        {
            _context.VideoGames.Add(game);
            _context.SaveChanges();
        }

        // Ažurira postojeću (note to self implement samo admin da ima access)
        public void Update(VideoGame game)
        {
            _context.VideoGames.Update(game);
            _context.SaveChanges();
        }

        // Briše igru po ID-u (note to self implement samo admin da ima access)
        public void Delete(int id)
        {
            var game = GetById(id);
            if (game != null)
            {
                _context.VideoGames.Remove(game);
                _context.SaveChanges();
            }
        }
    }
}
