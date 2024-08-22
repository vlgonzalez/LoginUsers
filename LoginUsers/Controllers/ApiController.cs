using LoginUsers.Models;
using LoginUsers.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginUsers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public UsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _accountService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("edit/{email}")]
        public async Task<IActionResult> EditUser(string email)
        {
            var user = await _accountService.FindUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }
            return Ok(user); 
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest(new { message = "ID do usuário não corresponde." });
            }

            var result = await _accountService.UpdateUserAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }

            return BadRequest(new { message = "Erro ao atualizar o usuário." });
        }

        [HttpDelete("Delete/{email}")]
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
                return Ok(new { success = true, message = "Usuário apagado com sucesso." });
            }

            return StatusCode(500, "Erro ao apagar usuário.");
        }


        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Problem(detail: "An error occurred.", statusCode: 500);
        }
    }

}
