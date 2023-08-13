using Fiap.TechChallenge.Api.Application.Dtos.Noticias;

namespace Fiap.TechChallenge.Api.Application.Services.Noticias;

public interface INoticiaService
{
    Task<NoticiaDto> CreateMeme(NoticiaInputDto dto);
    Task<ICollection<NoticiaDto>> GetAllMemes();
    Task<NoticiaDto> GetMemeById(Guid id);
    Task<bool> DeleteMemeById(Guid id);
    Task<NoticiaDto> UpdateMemeById(NoticiaInputUpdateDto dto);
}