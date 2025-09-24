namespace TomAuthApi.src.Application.Dtos;

public record UserDto(string _id,
                      string Name,
                      string Email,
                      string Password,
                      DateTime LastAccess);
