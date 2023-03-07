namespace Auth.Domain.ViewModels.Register
{
    public record RegisterResultViewModel(bool IsSuccess, string? Token, string ErrorMessage = "");
}
