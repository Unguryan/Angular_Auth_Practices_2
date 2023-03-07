using Auth.Domain.Models;
using Auth.Domain.ViewModels.AddUser;
using Auth.EF_Core.Dbo;
using AutoMapper;

namespace Auth.EF_Core.MapperProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<User, UserDbo>()
                .ReverseMap();
            CreateMap<RegisterViewModel, UserDbo>()
                .ReverseMap();

            CreateMap<Token, TokenDbo>()
                .ReverseMap();
        }
    }
}
