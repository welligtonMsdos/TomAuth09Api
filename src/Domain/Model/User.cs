using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TomAuthApi.src.Domain.Model;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime LastAccess { get; set; }
    public bool Active { get; set; }
}
