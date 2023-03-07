using MediatR;

namespace Auth.App.Commands.Logout
{
    public record LogoutCommand(string Token) : IRequest<LogoutCommandResult>;
}
