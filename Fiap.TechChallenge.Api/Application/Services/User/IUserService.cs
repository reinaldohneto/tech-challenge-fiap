using Fiap.TechChallenge.Api.Application.Dtos.User;

namespace Fiap.TechChallenge.Api.Application.Services.User;

public interface IUserService
{
    Task<UserAuthorizedDto?> CreateAsync(UserInputDto user);
    Task<UserAuthorizedDto?> LoginAsync(UserLoginDto  login);
}