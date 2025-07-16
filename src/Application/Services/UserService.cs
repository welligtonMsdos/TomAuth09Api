using AutoMapper;
using TomAuthApi.src.Application.Dtos;
using TomAuthApi.src.Application.Interfaces;
using TomAuthApi.src.Domain.Interfaces;

namespace TomAuthApi.src.Application.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<UserDto>> GetAllUsers()
    {
        return _mapper.Map<ICollection<UserDto>>(await _repository.GetAllUsers());
    }
}
