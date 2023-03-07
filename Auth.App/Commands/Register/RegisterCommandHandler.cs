using Auth.App.Services;
using Auth.Domain.ViewModels.AddUser;
using AutoMapper;
using MediatR;

namespace Auth.App.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterUserAsync(_mapper.Map<RegisterViewModel>(request));

            return _mapper.Map<RegisterCommandResult>(result);
        }
    }
}
