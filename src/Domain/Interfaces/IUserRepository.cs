using TomAuthApi.src.Domain.Model;

namespace TomAuthApi.src.Domain.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllUsers();
}
