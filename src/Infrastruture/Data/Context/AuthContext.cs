using MongoDB.Driver;
using TomAuthApi.src.Domain.Model;

namespace TomAuthApi.src.Infrastruture.Data.Context;

public class AuthContext
{
    private readonly IMongoDatabase _database;

    public AuthContext(IConfiguration configuration)
    {
        var connectString = configuration["MongoDB:ConnectionString"];

        var client = new MongoClient(connectString);

        _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("User");
}
