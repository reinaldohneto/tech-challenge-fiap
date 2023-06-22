using Fiap.TechChallenge.Api.Application.Services.Memes;
using Fiap.TechChallenge.Api.Configurations;
using Fiap.TechChallenge.WebPage.Services;
using ServiceStack.Configuration;

namespace Fiap.TechChallenge.WebPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            //builder.Services.AddSingleton<IMemeService>(new ApiFunctionalitiesService());
            builder.Services.AddSingleton<IMemeService, ApiFunctionalitiesService>();
            //builder.Services.Configure<UrlConfig>(builder.Configuration.GetSection("UrlConfig"));
            

            //builder.Configuration.GetValue<string>("UrlConfig");

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}