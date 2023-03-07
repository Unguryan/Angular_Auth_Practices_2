namespace Auth.Domain.ViewModels.Logout
{
    public record LogoutResultViewModel(bool IsSuccess, string ErrorMessage = "");
}
