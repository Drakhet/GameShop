using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.BLL.DTOs;

namespace GameShop.BLL.Interfaces
{
    public interface IStoreService
    {
        Task<List<VideoGameDto>> GetAvailableGamesForUserAsync(int userId);
        Task<List<VideoGameDto>> GetUserLibraryAsync(int userId);
        Task<bool> PurchaseGameAsync(int userId, int gameId);
        Task AddFundsAsync(int userId, decimal amount);
    }
}