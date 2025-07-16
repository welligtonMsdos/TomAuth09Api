
using Scalar.AspNetCore;
using TomAuthApi.src.Infrastruture.Data.Context;
using TomAuthApi.src.Infrastruture.DependencyInjection;

namespace TomAuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddSingleton<AuthContext>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    

            builder.Services.AddInterfaces(builder.Configuration);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(80);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();

                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
