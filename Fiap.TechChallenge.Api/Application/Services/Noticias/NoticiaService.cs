using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos.Noticias;
using Fiap.TechChallenge.Api.Application.Shared;
using Fiap.TechChallenge.Api.Application.Validators;
using Fiap.TechChallenge.Domain.Entities.Noticias;
using Fiap.TechChallenge.Infra.Infrastructure;

namespace Fiap.TechChallenge.Api.Application.Services.Noticias;

public class NoticiaService : INoticiaService
{
    private readonly NotificationContext _notificationContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public NoticiaService(NotificationContext notificationContext,
        IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<NoticiaDto> CreateMeme(NoticiaInputDto dto)
    {
        if (!dto.Validate(new NoticiaInputDtoValidator()))
        {
            _notificationContext.AddNotifications(dto.ValidationResult);
            return new NoticiaDto();
        }

        var noticiaDomain = _mapper.Map<Noticia>(dto);

        await _unitOfWork.NoticiaRepository.Create(noticiaDomain);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<NoticiaDto>(noticiaDomain);
    }

    public async Task<ICollection<NoticiaDto>> GetAllMemes()
    {
        var memes = await _unitOfWork
            .NoticiaRepository.GetAll();

        return _mapper.Map<ICollection<NoticiaDto>>(memes);
    }

    public async Task<NoticiaDto> GetMemeById(Guid id)
    {
        var meme = await _unitOfWork
            .NoticiaRepository.GetById(id);

        return _mapper.Map<NoticiaDto>(meme);
    }

    public async Task<bool> DeleteMemeById(Guid id)
    {
        var meme = await _unitOfWork
            .NoticiaRepository.Delete(id);

        return meme;
    }

    public async Task<NoticiaDto> UpdateMemeById(NoticiaInputUpdateDto dto)
    {

        var memeDomain = _mapper.Map<Noticia>(dto);
        _unitOfWork
            .NoticiaRepository.Update(memeDomain);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<NoticiaDto>(await _unitOfWork
            .NoticiaRepository
            .GetById(dto.Id));
    }
}
