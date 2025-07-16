using TomAuthApi.src.Application.Interfaces;
using TomAuthApi.src.Application.Services;
using TomAuthApi.src.Domain.Interfaces;
using TomAuthApi.src.Infrastruture.Repositories;

namespace TomAuthApi.src.Infrastruture.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
