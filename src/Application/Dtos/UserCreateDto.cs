namespace TomAuthApi.src.Application.Dtos;

public record UserCreateDto(string Name,
                            string Email,
                            string Password);
