using System.Reflection;
using Fiap.TechChallenge.Api.Application.Services.Authentication;
using Fiap.TechChallenge.Api.Application.Services.Noticias;
using Fiap.TechChallenge.Api.Application.Services.User;
using Fiap.TechChallenge.Api.Application.Shared;
using Fiap.TechChallenge.Infra.Infrastructure;

namespace Fiap.TechChallenge.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void DependencyInjectionConfig(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<NotificationContext>();

        services.AddScoped<INoticiaService, NoticiaService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}