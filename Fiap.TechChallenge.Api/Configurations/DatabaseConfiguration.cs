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
            .AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<SqlServerContext>();
    }
}