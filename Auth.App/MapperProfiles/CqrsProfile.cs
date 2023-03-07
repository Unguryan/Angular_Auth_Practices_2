using Auth.App.Commands.Login;
using Auth.App.Commands.Register;
using Auth.Domain.ViewModels.AddUser;
using Auth.Domain.ViewModels.Login;
using Auth.Domain.ViewModels.Register;
using AutoMapper;

namespace Auth.App.MapperProfiles
{
    public class CqrsProfile : Profile
    {
        public CqrsProfile()
        {
            CreateMap<LoginCommand, LoginViewModel>()
                .ReverseMap();
            CreateMap<LoginCommandResult, LoginResultViewModel>()
                .ReverseMap();

            CreateMap<RegisterCommand, RegisterViewModel>()
                .ReverseMap();
            CreateMap<RegisterCommandResult, RegisterResultViewModel>()
                .ReverseMap();
        }
    }
}
