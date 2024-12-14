using ExemploCleanArchitecture.Application.Interfaces;
using ExemploCleanArchitecture.Application.Services;
using ExemploCleanArchitecture.Domain.Interfaces;
using ExemploCleanArchitecture.Infra.Data.Context;
using ExemploCleanArchitecture.Infra.Data.Repositories;
using ExemploCleanArchitecture.Infra.IoC.Services.Crypt;
using ExemploCleanArchitecture.Infra.IoC.Services.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploCleanArchitecture.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        string issuer = configuration.GetValue<string>("JwtConfiguration:Issuer")!;
        int validHours = configuration.GetValue<int>("JwtConfiguration:ValidHours");
        string connectionString = configuration.GetConnectionString("LocalHost")!;

        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<ICryptography, Cryptography>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();

        services.AddSingleton<ITokenGenerator>(c => new TokenGenerator(issuer, validHours));

        return services;
    }
}

