namespace Auth.App.Commands.Login
{
    public record LoginCommandResult(bool IsSuccess, string Token, string ErrorMessage = "");
}
