using Auth.Domain.ViewModels.AddUser;
using Auth.Domain.ViewModels.Login;
using Auth.Domain.ViewModels.Register;

namespace Auth.App.Services
{
    public interface IAuthService
    {
        Task<LoginResultViewModel> LoginByEmailAsync(string email, string password, bool remember);

        Task<LoginResultViewModel> LoginByPhoneAsync(string phone, string password, bool remember);

        Task<RegisterResultViewModel> RegisterUserAsync(RegisterViewModel addUserViewModel);
    }
}
