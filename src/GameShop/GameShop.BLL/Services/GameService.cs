using GameShop.DAL.Models;
using GameShop.DAL.Repositories;

namespace GameShop.BLL.Services
{
    public class GameService
    {
        private readonly GameRepository _repo;

        public GameService(GameRepository repo)
        {
            _repo = repo;
        }

        public List<VideoGame> GetAll() => _repo.GetAll();
        public VideoGame GetById(int id) => _repo.GetById(id);
        public void Create(VideoGame game) => _repo.Add(game);
        public void Update(VideoGame game) => _repo.Update(game);
        public void Delete(int id) => _repo.Delete(id);
    }
}