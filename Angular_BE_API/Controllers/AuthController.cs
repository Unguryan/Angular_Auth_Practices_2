using Auth.App.Commands.Login;
using Auth.App.Commands.Register;
using Auth.Domain.ViewModels.AddUser;
using Auth.Domain.ViewModels.Login;
using Auth.Domain.ViewModels.Register;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_BE_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResultViewModel> Login([FromBody] LoginViewModel form)
        {
            var result = await _mediator.Send(_mapper.Map<LoginCommand>(form));

            return _mapper.Map<LoginResultViewModel>(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<RegisterResultViewModel> Register([FromBody] RegisterViewModel form)
        {
            var result = await _mediator.Send(_mapper.Map<RegisterCommand>(form));

            return _mapper.Map<RegisterResultViewModel>(result);
        }

        //[HttpPost]
        //[Route("logout")]
        //public async Task<LoginResultViewModel> Logout([FromBody] LoginViewModel form)
        //{
        //    var result = await _mediator.Send(_mapper.Map<LoginCommand>(form));

        //    return _mapper.Map<LoginResultViewModel>(result);
        //}
    }
}
