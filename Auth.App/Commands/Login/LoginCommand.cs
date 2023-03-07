using MediatR;

namespace Auth.App.Commands.Login
{
   public record LoginCommand(string Password, string Email = "", string Phone = "", bool Remember = false) : IRequest<LoginCommandResult>;
   
}
