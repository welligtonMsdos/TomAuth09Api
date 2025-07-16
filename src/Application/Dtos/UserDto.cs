namespace TomAuthApi.src.Application.Dtos;

public class UserDto
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime LastAccess { get; set; }
}
