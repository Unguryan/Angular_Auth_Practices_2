using Auth.Domain.Models;
using Auth.Domain.ViewModels.AddUser;

namespace Auth.App.Repositories
{
    public interface IAuthRepository
    {
        Task<Token?> AddTokenAsync(string token, DateTime expiredAt, int userId);
        Task<User?> AddUserAsync(RegisterViewModel vm);
        Task<List<Token>> GetTokensAsync();
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByPhoneAsync(string phone);
        Task<User?> GetUserByToken(string token);
        Task<string?> GetUserPasswordAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task<Token?> RemoveTokenAsync(string token);
    }
}
