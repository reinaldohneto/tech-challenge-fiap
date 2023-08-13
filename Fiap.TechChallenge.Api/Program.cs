using Fiap.TechChallenge.Api.Application.Dtos.Noticias;
using Fiap.TechChallenge.Api.Application.Dtos.User;
using Fiap.TechChallenge.Api.Application.Services.Noticias;
using Fiap.TechChallenge.Api.Application.Services.User;
using Fiap.TechChallenge.Api.Application.Shared;
using Fiap.TechChallenge.Api.Configurations;
using Fiap.TechChallenge.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.DependencyInjectionConfig();

builder.Services.AddAuthenticationConfiguration(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

var root = app.MapGroup("/v1/")
    .AddEndpointFilter<NotificationFilter>();

var noticias = root
    .MapGroup("noticias")
    .RequireAuthorization();

var user = root
    .MapGroup("user");

noticias
    .MapPost("", async (INoticiaService service,
        NoticiaInputDto dto) => await service.CreateMeme(dto))
    .Produces<NoticiaDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

noticias
    .MapGet("", async (INoticiaService service) =>
        await service.GetAllMemes())
    .Produces<ICollection<NoticiaDto>>();

noticias
    .MapGet("{id:guid}", async (INoticiaService service, Guid id) =>
        await service.GetMemeById(id))
    .Produces<ICollection<NoticiaDto>>();

noticias
    .MapDelete("{id:guid}", async (INoticiaService service, Guid id) =>
        await service.DeleteMemeById(id))
    .Produces<ICollection<NoticiaDeleteDto>>();

noticias
    .MapPut("", async (INoticiaService service,
        NoticiaInputUpdateDto dto) => await service.UpdateMemeById(dto))
    .Produces<NoticiaUpdateDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

user.MapPost("create", async (IUserService service, 
    UserInputDto dto) => await service.CreateAsync(dto))
    .Produces<UserAuthorizedDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

user.MapPost("login", async (IUserService service,
        UserLoginDto dto) => await service.LoginAsync(dto))
    .Produces<UserAuthorizedDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

app.Run();
