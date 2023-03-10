using Auth.App.Repositories;
using Auth.App.Services;
using Auth.Domain.ViewModels.AddUser;
using Auth.Domain.ViewModels.Login;
using Auth.Domain.ViewModels.Logout;
using Auth.Domain.ViewModels.Register;

namespace Auth.Infra.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenGenerator _generator;
        private readonly IAuthRepository _repository;
        private readonly IEncodePasswordService _passwordService;

        public AuthService(ITokenGenerator generator, IAuthRepository repository, IEncodePasswordService passwordService)
        {
            _generator = generator;
            _repository = repository;
            _passwordService = passwordService;
        }

        public async Task<LoginResultViewModel> LoginByEmailAsync(string email, string password, bool remember)
        {
            var user = await _repository.GetUserByEmailAsync(email);

            if(user == null)
            {
                //Add Message to dictionary
                return new LoginResultViewModel(false, "", $"User with {email} - is not found.");
            }

            var actualPassword = await _passwordService.DecodePasswordAsync(await _repository.GetUserPasswordAsync(user.Id));

            if(password != actualPassword)
            {
                return new LoginResultViewModel(false, "", $"User with {email} - is exist, but password mismatch.");
            }

            var token = await _generator.GenerateTokenAsync(user.Name, user.Surname, user.Email, user.Phone, remember);

            var res = await _repository.AddTokenAsync(token, remember ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1), user.Id);

            if(res == null)
            {
                return new LoginResultViewModel(false, null, $"Server error.");
            }

            return new LoginResultViewModel(true, res?.TokenData);
        }

        public async Task<LoginResultViewModel> LoginByPhoneAsync(string phone, string password, bool remember)
        {
            if (phone.Contains("-"))
            {
                phone = phone.Replace("-", "");
            }

            var user = await _repository.GetUserByPhoneAsync(phone);

            if (user == null)
            {
                //Add Message to dictionary
                return new LoginResultViewModel(false, "", $"User with {phone} - is not found.");
            }

            var actualPassword = await _passwordService.DecodePasswordAsync(await _repository.GetUserPasswordAsync(user.Id));

            if (password != actualPassword)
            {
                return new LoginResultViewModel(false, "", $"User with {phone} - is exist, but password mismatch.");
            }

            var token = await _generator.GenerateTokenAsync(user.Name, user.Surname, user.Email, user.Phone, remember);

            var res = await _repository.AddTokenAsync(token, remember ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1), user.Id);

            if (res == null)
            {
                return new LoginResultViewModel(false, null, "Server error.");
            }

            return new LoginResultViewModel(true, res?.TokenData);
        }

        public async Task<LogoutResultViewModel> LogoutAsync(LogoutViewModel logoutViewModel)
        {
            var result = await _repository.RemoveTokenAsync(logoutViewModel.Token);

            if(result == null)
            {
                return new LogoutResultViewModel(false, "Server error.");
            }

            return new LogoutResultViewModel(true);
        }

        public async Task<RegisterResultViewModel> RegisterUserAsync(RegisterViewModel addUserViewModel)
        {
            var user = await _repository.GetUserByEmailAsync(addUserViewModel.Email);
            if(user != null)
            {
                return new RegisterResultViewModel(false, null, $"User with {addUserViewModel.Email} - is exist.");
            }

            user = await _repository.GetUserByPhoneAsync(addUserViewModel.Phone);
            if (user != null)
            {
                return new RegisterResultViewModel(false, null, $"User with {addUserViewModel.Phone} - is exist.");
            }

            var result = await _repository.AddUserAsync(addUserViewModel);

            if(result == null)
            {
                return new RegisterResultViewModel(false, null, $"Server error.");
            }

            var token = await _generator.GenerateTokenAsync(result.Name, result.Surname, result.Email, result.Phone);

            var res = await _repository.AddTokenAsync(token, DateTime.UtcNow.AddDays(1), result.Id);

            if (res == null)
            {
                return new RegisterResultViewModel(false, null, $"Server error.");
            }

            return new RegisterResultViewModel(true, res?.TokenData);
        }
    }
}
