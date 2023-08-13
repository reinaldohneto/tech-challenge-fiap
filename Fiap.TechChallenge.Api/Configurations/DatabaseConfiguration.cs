using Fiap.TechChallenge.Infra.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Api.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDataBase(this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddDbContext<SqlServerContext>(opt => 
            opt.UseSqlServer(config.GetValue<string>("ConnectionStrings:Fiap.TechChallenge.SqlServer"),
                b => b.MigrationsAssembly("Fiap.TechChallenge.Infra")))
            .AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;

                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequiredUniqueChars = 1;
            })
            .AddEntityFrameworkStores<SqlServerContext>();
    }
}