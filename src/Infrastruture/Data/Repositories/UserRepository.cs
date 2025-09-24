using MongoDB.Driver;
using TomAuthApi.src.Domain.Interfaces;
using TomAuthApi.src.Domain.Model;
using TomAuthApi.src.Infrastruture.Data.Context;

namespace TomAuthApi.src.Infrastruture.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthContext _context;

    public UserRepository(AuthContext context)
    {
        _context = context;
    }

    public async Task<ICollection<User>> GetAll()
    {
        var users = await _context.Users.Find(u => u.Active).ToListAsync();

        return users;
    }

    public async Task<User> GetById(string id)
    {
        var user = await _context.Users
             .Find(u => u._id == id && u.Active)             
             .FirstOrDefaultAsync();

        return user;
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users
            .Find(u => u.Email == email && u.Active)
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<User> Post(User obj)
    {
        await _context.Users.InsertOneAsync(obj);

        return obj;
    }

    public async Task<bool> DeleteById(string id)
    {
        try
        {
            await _context.Users.UpdateOneAsync(
            u => u._id == id,
            Builders<User>.Update
                .Set(u => u.Active, false));

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<User> Put(string id, User obj)
    {
        await _context.Users.UpdateOneAsync(
            u => u._id == id,
            Builders<User>.Update
                .Set(u => u.Name, obj.Name)
                .Set(u => u.Email, obj.Email)
                .Set(u => u.LastAccess, DateTime.Now));

        var user = await _context.Users.Find(u => u._id == id).FirstOrDefaultAsync();

        return user;
    }
}
