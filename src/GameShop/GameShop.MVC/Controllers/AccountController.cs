using GameShop.BLL.DTOs;
using GameShop.BLL.Interfaces;
using GameShop.MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userService.AuthenticateAsync(model.Username, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Pogrešno korisničko ime ili lozinka.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("UserId", user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Games");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new UserDto
                {
                    Username = vm.Username,
                    Email = vm.Email,
                    Password = vm.Password,
                    Role = "Customer"
                };
                await _userService.CreateAsync(dto);
                return RedirectToAction("Login");
            }
            return View(vm);
        }
        [Authorize]
        public async Task<IActionResult> MyProfile()
        {
            int userId = GetCurrentUserId();
            var user = await _userService.GetByIdAsync(userId);

            if (user == null) return NotFound();

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            int userId = GetCurrentUserId();
            var user = await _userService.GetByIdAsync(userId);

            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserDto model)
        {
            int userId = GetCurrentUserId();
            model.Id = userId;

            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Role");

            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(model);

                // Potencijalno da se refresh-uje cookie kada se menjaju podaci ako ne zaboravim
                TempData["SuccessMessage"] = "Profil je uspešno ažuriran!";
                return RedirectToAction(nameof(MyProfile));
            }

            return View(model);
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

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            int userId = GetCurrentUserId();

            bool result = await _userService.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);

            if (result)
            {
                TempData["SuccessMessage"] = "Lozinka je uspešno promenjena!";
                return RedirectToAction(nameof(MyProfile));
            }
            else
            {
                ModelState.AddModelError("", "Stara lozinka nije ispravna.");
                return View(model);
            }
        }
    }
}