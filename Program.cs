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

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddSingleton<AuthContext>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInterfaces(builder.Configuration);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ListenAnyIP(80);
            });

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            app.MapScalarApiReference();

            app.MapOpenApi();
            //}

            app.UseCors("CorsPolicy");

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
