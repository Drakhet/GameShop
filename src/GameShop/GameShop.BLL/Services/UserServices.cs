using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.DAL.Models;
using GameShop.DAL.Repositories;

namespace GameShop.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;

        public UserService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<User> GetAll() => _userRepo.GetAll();
        public User GetById(int id) => _userRepo.GetById(id);
        public void Create(User user) => _userRepo.Add(user);
        public void Delete(int id) => _userRepo.Delete(id);
        public void Update(User user) => _userRepo.Update(user);
    }
}