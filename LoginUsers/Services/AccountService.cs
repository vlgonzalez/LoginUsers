using LoginUsers.Helper;
using LoginUsers.Models;
using LoginUsers.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoginUsers.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmail _emailService;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IEmail emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<SignInResult> SignInAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterVM model)
        {
            User user = new()
            {
                Name = model.Name,
                UserName = model.Email,
                Email = model.Email,
            };

            return await _userManager.CreateAsync(user, model.Password!);
        }

        public async Task<SignInResult> SignInUserAsync(LoginVM model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, model.RememberMe, false);
        }

        public async Task<User?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task SignInUserAsync(User user)
        {
            await _signInManager.SignInAsync(user, false);
        }

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> SendForgotPasswordEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var newPassword = GenerateRandomPassword();

                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (resetPasswordResult.Succeeded)
                {
                    // Envia o e-mail com a nova senha
                    _emailService.SendEmail(user.Email,user.UserName,newPassword);
                    return true;
                }
            }
            return false;

        }
        public string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            var random = new Random();
            return new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task<User?> FindUserByIdAsync(string id)
        {
            // Convertendo o ID para string se necessário
            var userId = id.ToString();
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Usuário não encontrado." });
            }

            existingUser.Name = user.Name; 
            existingUser.Email = user.Email;

            var result = await _userManager.UpdateAsync(existingUser);
            return result;
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }
    }

}

