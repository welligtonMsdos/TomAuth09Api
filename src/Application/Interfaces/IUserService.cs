using TomAuthApi.src.Application.Dtos;

namespace TomAuthApi.src.Application.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDto>> GetAllUsers();
    Task<UserDto> GetUserById(string id);
    Task<UserDto> GetUserByEmail(string email);
}
