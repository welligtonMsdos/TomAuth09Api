using AutoMapper;
using TomAuthApi.src.Application.Dtos;
using TomAuthApi.src.Domain.Model;

namespace TomAuthApi.src.Infrastruture.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
