namespace Auth.App.Commands.Register
{
    public record RegisterCommandResult(bool IsSuccess, string Token, string ErrorMessage = "");
}
