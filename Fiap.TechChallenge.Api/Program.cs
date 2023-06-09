using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Fiap.TechChallenge.Api.Application.Shared;
using Fiap.TechChallenge.Api.Configurations;
using Fiap.TechChallenge.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.DependencyInjectionConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var root = app.MapGroup("/v1/")
    .AddEndpointFilter<NotificationFilter>();

root
    .MapPost("meme", async (IMemeService service,
        MemeInputDto dto) => await service.CreateMeme(dto))
    .Produces<MemeDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

root
    .MapGet("meme", async (IMemeService service) =>
        await service.GetAllMemes())
    .Produces<ICollection<MemeDto>>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
