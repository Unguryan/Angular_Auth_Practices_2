namespace Auth.Domain.ViewModels.Login
{
    public record LoginViewModel(string Password, string Email = "", string Phone = "", bool Remember = false);
}
