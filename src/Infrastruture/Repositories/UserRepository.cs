using MongoDB.Driver;
using TomAuthApi.src.Domain.Interfaces;
using TomAuthApi.src.Domain.Model;
using TomAuthApi.src.Infrastruture.Data.Context;

namespace TomAuthApi.src.Infrastruture.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthContext _context;

    public UserRepository(AuthContext context)
    {
        _context = context;
    }

    public async Task<ICollection<User>> GetAllUsers()
    {
        var users = await _context.Users.Find(_ => true).ToListAsync();

        return users;
    }
}
