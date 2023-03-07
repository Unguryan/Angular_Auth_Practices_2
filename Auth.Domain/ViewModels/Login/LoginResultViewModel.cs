namespace Auth.Domain.ViewModels.Login
{
    public record LoginResultViewModel(bool IsSuccess, string? Token, string ErrorMessage = "");
}
