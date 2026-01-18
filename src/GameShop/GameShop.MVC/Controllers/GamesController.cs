using Microsoft.AspNetCore.Mvc;
using GameShop.BLL.Services;
using GameShop.DAL.Models;

namespace GameShop.MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        // 1. TABELARNI PRIKAZ (Read)
        public IActionResult Index()
        {
            var igre = _gameService.GetAll();
            return View(igre);
        }

        // 2. FORMA ZA UNOS (Create - GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3. ČUVANJE UNOSA (Create - POST)
        [HttpPost]
        public IActionResult Create(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                _gameService.Create(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // 4. BRISANJE
        public IActionResult Delete(int id)
        {
            _gameService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}