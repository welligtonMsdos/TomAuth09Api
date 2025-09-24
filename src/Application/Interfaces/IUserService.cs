using TomAuthApi.src.Application.Dtos;

namespace TomAuthApi.src.Application.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDto>> GetAll();
    Task<UserDto> GetById(string id);
    Task<UserDto> GetByEmail(string email);
    Task<UserDto> Post(UserCreateDto userCreateDto);
    Task<bool> DeleteById(string id);
    Task<UserDto> Put(string id, UserUpdateDto userUpdateDto);
}
