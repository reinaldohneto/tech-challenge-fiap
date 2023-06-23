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

app.UseSwagger();
app.UseSwaggerUI();


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

root
    .MapGet("meme/{id}", async (IMemeService service,string id) =>
        await service.GetMemeById(id))
    .Produces<ICollection<MemeDto>>();

root
    .MapDelete("meme/{id}", async (IMemeService service,string id) =>
        await service.DeleteMemeById(id))
    .Produces<ICollection<MemeDeleteDto>>();

root
    .MapPut("meme", async (IMemeService service,
        MemeInputUpdateDto dto) => await service.UpdateMemeById(dto))
    .Produces<MemeUpdateDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);


app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
