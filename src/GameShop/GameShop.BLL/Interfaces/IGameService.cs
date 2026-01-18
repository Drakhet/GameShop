using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.DAL.Models;
using GameShop.BLL.DTOs;

namespace GameShop.BLL.Interfaces
{
    public interface IGameService
    {
        Task<List<VideoGameDto>> GetAllAsync();
        Task<VideoGameDto?> GetByIdAsync(int id);
        Task CreateAsync(VideoGameDto gameDto);
        Task UpdateAsync(VideoGameDto gameDto);
        Task DeleteAsync(int id);
    }
}