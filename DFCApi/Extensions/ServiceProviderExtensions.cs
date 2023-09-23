using API.Persistences.Repositories;
using API.Persistences.Repositories.Interfaces;
using API.Services;
using API.Services.Interface;

namespace API.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static WebApplicationBuilder AddDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

            builder.Services.AddTransient<ITokenService, TokenService>();
            builder.Services.AddTransient<IDrawTeamService, DrawTeamService>();

            return builder;
        }
    }
}