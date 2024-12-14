using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ExemploCleanArchitecture.Infra.IoC;

public static class DependencyInjectionSwagger
{
    const string AUTHENTICATION_TYPE = "Bearer";
    public static IServiceCollection AddInfraestructureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {

            options.AddSecurityDefinition(AUTHENTICATION_TYPE, new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                        Enter 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer 123456abdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = AUTHENTICATION_TYPE
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = AUTHENTICATION_TYPE
                        },
                        Scheme = "oauth2",
                        Name = AUTHENTICATION_TYPE,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        return services;
    }
}

