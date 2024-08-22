using LoginUsers.Models;
using LoginUsers.Services;
using LoginUsers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace LoginUsers.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Login", "Account");
            }

            var userEmail = User.Identity?.Name; // Assumindo que o email é usado como UserName
            var user = await _accountService.FindUserByEmailAsync(userEmail);

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var users = await _accountService.GetAllUsersAsync();
            var viewModel = new ListUsersVM
            {
                Users = users.Select(u => new UserDto
                {
                    Name = u.Name,
                    Email = u.Email
                    // Mapeie outras propriedades conforme necessário
                }).ToList(),
                Message = TempData["Message"] as string
            };

            return View(viewModel);
        }

      
        public async Task<IActionResult> EditUser(string email)
        {
            var user = await _accountService.FindUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new EditUserVM
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
                // Mapeie outras propriedades conforme necessário
            };

            return View(viewModel);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string email)
        {
            var user = await _accountService.FindUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _accountService.DeleteUserAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = "Usuário apagado com sucesso.";
                return Json(new { success = true, message = "Usuário apagado com sucesso." });
            }

            return Json(new { success = false, message = "Erro ao apagar usuário." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
