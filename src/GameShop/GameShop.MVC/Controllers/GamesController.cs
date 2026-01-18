using GameShop.BLL.Interfaces;
using GameShop.BLL.Services;
using GameShop.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }


        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllAsync();
            return View(games);
        }

        public async Task<IActionResult> Details(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Genre,Description,Price,ReleaseDate")] VideoGame game)
        {
            if (ModelState.IsValid)
            {
                await _gameService.CreateAsync(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Price,ReleaseDate")] VideoGame game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _gameService.UpdateAsync(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gameService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}