using GameShop.BLL.DTOs;
using GameShop.BLL.Interfaces;
using GameShop.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GameShop.MVC.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var dtos = await _gameService.GetAllAsync();

            var vms = dtos.Select(d => new GameViewModel
            {
                Id = d.Id,
                Title = d.Title,
                Genre = d.Genre,
                Price = d.Price,
                ReleaseDate = d.ReleaseDate,
                Description = d.Description,
                CoverImage = d.CoverImage
            }).ToList();

            return View(vms);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _gameService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new GameViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Genre = dto.Genre,
                Price = dto.Price,
                ReleaseDate = dto.ReleaseDate,
                Description = dto.Description,
                CoverImage = dto.CoverImage
            };
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(GameViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new VideoGameDto
                {
                    Title = vm.Title,
                    Genre = vm.Genre,
                    Price = vm.Price,
                    ReleaseDate = vm.ReleaseDate,
                    Description = vm.Description,
                    CoverImage = string.IsNullOrEmpty(vm.CoverImage) ? "no-image.jpg" : vm.CoverImage
                };
                await _gameService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _gameService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new GameViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Genre = dto.Genre,
                Price = dto.Price,
                ReleaseDate = dto.ReleaseDate,
                Description = dto.Description,
                CoverImage = dto.CoverImage
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, GameViewModel vm)
        {
            if (id != vm.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var dto = new VideoGameDto
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    Genre = vm.Genre,
                    Price = vm.Price,
                    ReleaseDate = vm.ReleaseDate,
                    Description = vm.Description,
                    CoverImage = string.IsNullOrEmpty(vm.CoverImage) ? "no-image.jpg" : vm.CoverImage
                };
                await _gameService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _gameService.GetByIdAsync(id);
            if (dto == null) return NotFound();

            var vm = new GameViewModel { Id = dto.Id, Title = dto.Title, Genre = dto.Genre, Price = dto.Price };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gameService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}