using LoginUsers.Models;
using LoginUsers.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LoginUsers.Services
{
    public interface IAccountService
    {
        //login
        Task<SignInResult> SignInAsync(string email, string password, bool rememberMe);

        //Registro
        Task<IdentityResult> RegisterUserAsync(RegisterVM model);
        Task<SignInResult> SignInUserAsync(LoginVM model);
        Task<User?> FindUserByEmailAsync(string email);
        Task SignInUserAsync(User user);
        Task SignOutUserAsync();
        Task<bool> SendForgotPasswordEmailAsync(string email);
        string GenerateRandomPassword(int length = 12);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<User> FindUserByIdAsync(string id);
        Task<IdentityResult> DeleteUserAsync(User user);
    }
}
