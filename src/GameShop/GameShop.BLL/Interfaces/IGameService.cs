using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.DAL.Models;

namespace GameShop.BLL.Interfaces
{
    public interface IGameService
    {
        public Task<List<VideoGame>> GetAllAsync();
        public Task<VideoGame?> GetByIdAsync(int id);
        public Task<VideoGame> CreateAsync(VideoGame game);
        public Task<VideoGame> UpdateAsync(VideoGame game);
        public Task<bool> DeleteAsync(int id);
    }
}