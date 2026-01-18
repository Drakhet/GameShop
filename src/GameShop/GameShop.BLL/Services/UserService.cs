using Microsoft.EntityFrameworkCore;
using GameShop.BLL.DTOs;
using GameShop.BLL.Interfaces;
using GameShop.DAL;
using GameShop.DAL.Models;

namespace GameShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return null;

            return new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            };
        }

        public async Task CreateAsync(UserDto dto)
        {
            var entity = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var entity = await _context.Users.FindAsync(dto.Id);
            if (entity != null)
            {
                entity.Username = dto.Username;
                entity.Email = dto.Email;
                entity.Password = dto.Password;
                entity.Role = dto.Role;

                _context.Users.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}