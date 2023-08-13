using Fiap.TechChallenge.Api.Application.Dtos.User;
namespace Fiap.TechChallenge.Api.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<UserAuthorizedDto?> GenerateAuthorizedToken(string userName, string password);
}