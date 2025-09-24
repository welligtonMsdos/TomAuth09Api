using TomAuthApi.src.Domain.Model;

namespace TomAuthApi.src.Domain.Interfaces;

public interface IUserRepository: IQuery<User>, ICommand<User>
{    
    Task<User> GetByEmail(string email);   
}
