using Auth.App.Commands.Login;
using Auth.App.Services;
using Auth.Domain.ViewModels.Logout;
using AutoMapper;
using MediatR;

namespace Auth.App.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutCommandResult>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LogoutCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<LogoutCommandResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.LogoutAsync(_mapper.Map<LogoutViewModel>(request));
            return _mapper.Map<LogoutCommandResult>(result);
        }
    }
}
