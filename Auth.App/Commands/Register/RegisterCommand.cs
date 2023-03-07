using MediatR;

namespace Auth.App.Commands.Register
{
    public record RegisterCommand(string Name, string Surname, string Email, string Phone, string Password) : IRequest<RegisterCommandResult>;
}
