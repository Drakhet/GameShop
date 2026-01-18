using GameShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameShop.DAL.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

    
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

     
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

    
        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

       
        public User Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}