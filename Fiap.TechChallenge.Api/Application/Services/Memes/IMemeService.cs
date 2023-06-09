using Fiap.TechChallenge.Api.Application.Dtos;

namespace Fiap.TechChallenge.Api.Application.Services.Memes;

public interface IMemeService
{
    Task<MemeDto> CreateMeme(MemeInputDto dto);
    Task<ICollection<MemeDto>> GetAllMemes();
}