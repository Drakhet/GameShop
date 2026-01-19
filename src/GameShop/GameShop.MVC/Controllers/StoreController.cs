using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameShop.BLL.Interfaces;
using GameShop.MVC.ViewModels;
using GameShop.BLL.DTOs;

namespace GameShop.MVC.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IUserService _userService;

        public StoreController(IStoreService storeService, IUserService userService)
        {
            _storeService = storeService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = GetCurrentUserId();

            var games = await _storeService.GetAvailableGamesForUserAsync(userId);
            UserDto? user = await _userService.GetByIdAsync(userId);

            ViewBag.Balance = user?.Balance ?? 0;

            var vms = games.Select(g => new GameViewModel
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate,
                Description = g.Description
            }).ToList();

            return View(vms);
        }

        public async Task<IActionResult> MyLibrary()
        {
            int userId = GetCurrentUserId();
            var games = await _storeService.GetUserLibraryAsync(userId);

            var vms = games.Select(g => new GameViewModel
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate,
                Description = g.Description
            }).ToList();

            return View(vms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(int id)
        {
            int userId = GetCurrentUserId();
            bool success = await _storeService.PurchaseGameAsync(userId, id);

            if (success)
            {
                TempData["SuccessMessage"] = "Uspešna kupovina! Igra je dodata u tvoju biblioteku.";
                return RedirectToAction(nameof(MyLibrary));
            }
            else
            {
                TempData["ErrorMessage"] = "Kupovina nije uspela. Proverite stanje na računu.";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> AddFunds()
        {
            int userId = GetCurrentUserId();
            UserDto? user = await _userService.GetByIdAsync(userId);
            ViewBag.Balance = user?.Balance ?? 0;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFunds(decimal amount)
        {
            if (amount <= 0)
            {
                ModelState.AddModelError("", "Iznos mora biti pozitivan.");
                return View();
            }

            int userId = GetCurrentUserId();
            await _storeService.AddFundsAsync(userId, amount);

            TempData["SuccessMessage"] = $"Uspešno ste dodali {amount:N2} RSD na svoj račun.";
            return RedirectToAction(nameof(Index));
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            return 0;
        }
    }
}