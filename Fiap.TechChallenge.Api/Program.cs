using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Noticias;
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
    .MapPost("noticias", async (INoticiaService service,
        NoticiaInputDto dto) => await service.CreateMeme(dto))
    .Produces<NoticiaDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

root
    .MapGet("noticias", async (INoticiaService service) =>
        await service.GetAllMemes())
    .Produces<ICollection<NoticiaDto>>();

root
    .MapGet("noticias/{id:guid}", async (INoticiaService service, Guid id) =>
        await service.GetMemeById(id))
    .Produces<ICollection<NoticiaDto>>();

root
    .MapDelete("noticias/{id:guid}", async (INoticiaService service, Guid id) =>
        await service.DeleteMemeById(id))
    .Produces<ICollection<NoticiaDeleteDto>>();

root
    .MapPut("noticias", async (INoticiaService service,
        NoticiaInputUpdateDto dto) => await service.UpdateMemeById(dto))
    .Produces<NoticiaUpdateDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);


app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
