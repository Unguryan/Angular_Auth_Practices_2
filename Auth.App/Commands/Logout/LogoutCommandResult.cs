namespace Auth.App.Commands.Logout
{
    public record LogoutCommandResult(bool IsSuccess, string ErrorMessage = "");
}
