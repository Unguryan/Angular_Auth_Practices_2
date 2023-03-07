namespace Auth.Domain.ViewModels.AddUser
{
    public record RegisterViewModel(string Name, string Surname, string Email, string Phone, string Password);
}
