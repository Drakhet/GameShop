using GameShop.BLL.DTOs;
using GameShop.BLL.Interfaces;
using GameShop.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GameShop.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var dtos = await _userService.GetAllAsync();
            var viewModels = dtos.Select(d => new UserViewModel
            {
                Id = d.Id,
                Username = d.Username,
                Email = d.Email,
                Role = d.Role
            }).ToList();

            return View(viewModels);
        }
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _userService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            var vm = new UserViewModel
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                Role = dto.Role
            };
            return View(vm);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel vm) 
        {
            if (ModelState.IsValid)
            {
                var dto = new UserDto
                {
                    Username = vm.Username,
                    Email = vm.Email,
                    Password = vm.Password,
                    Role = vm.Role
                };

                await _userService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _userService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            var vm = new UserViewModel
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                Role = dto.Role
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel vm)
        {
            if (id != vm.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var userDto = new UserDto
                {
                    Id = vm.Id,
                    Username = vm.Username,
                    Email = vm.Email,
                    Password = vm.Password,
                    Role = vm.Role
                };
                await _userService.UpdateAsync(userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _userService.GetByIdAsync(id);
            if (dto == null) return NotFound();
            var vm = new UserViewModel
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}