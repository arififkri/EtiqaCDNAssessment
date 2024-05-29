using etiqa.Domain.Model;
using etiqaAPI.Dto.UserDto;
using AutoMapper;
using etiqaAPI.Dto.AuthenticationDto;

namespace etiqaAPI.Automapper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<SignInDto, User>();
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<EditUserDto, User>();

        }


    }
}
