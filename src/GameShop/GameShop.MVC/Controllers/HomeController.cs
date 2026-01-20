using System.Diagnostics;
using GameShop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using GameShop.BLL.Interfaces; 
using GameShop.MVC.ViewModels; 
using GameShop.BLL.DTOs;      

namespace GameShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _gameService;
        public HomeController(ILogger<HomeController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var gameDtos = await _gameService.GetAllAsync();

            var gameVms = gameDtos.Select(g => new GameViewModel
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                Description = g.Description,
                ReleaseDate = g.ReleaseDate
                // Ako imaš sliku, dodaj je ovde
            }).ToList();

            return View(gameVms);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
