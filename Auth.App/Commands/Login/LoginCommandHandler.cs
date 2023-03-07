using Auth.App.Services;
using AutoMapper;
using MediatR;

namespace Auth.App.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                var result = await _authService.LoginByEmailAsync(request.Email, request.Password, request.Remember);
                return _mapper.Map<LoginCommandResult>(result);
            }

            if (!string.IsNullOrEmpty(request.Phone))
            {
                var result = await _authService.LoginByPhoneAsync(request.Phone, request.Password, request.Remember);
                return _mapper.Map<LoginCommandResult>(result);
            }

            return new LoginCommandResult(false, string.Empty, "Server Error.");
        }
    }
}
