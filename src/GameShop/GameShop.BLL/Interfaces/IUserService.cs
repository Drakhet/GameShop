using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.DAL.Models;
using GameShop.BLL.DTOs;

namespace GameShop.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> AuthenticateAsync(string username, string password);
        Task CreateAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto user);
        Task DeleteAsync(int id);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}
