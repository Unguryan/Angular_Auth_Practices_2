namespace Angular_BE_API.ViewModels
{
    public record LoginViewModel(string Password, string Email = "", string Phone = "");
}
