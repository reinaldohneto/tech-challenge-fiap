using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Shared;
using Fiap.TechChallenge.Api.Application.Validators;
using Fiap.TechChallenge.Domain.Entities.Memes;
using Fiap.TechChallenge.Infra.Infrastructure;

namespace Fiap.TechChallenge.Api.Application.Services.Memes;

public class MemeService : IMemeService
{
    private readonly NotificationContext _notificationContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MemeService(NotificationContext notificationContext, 
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MemeDto> CreateMeme(MemeInputDto dto)
    {
        if (!dto.Validate(new MemeInputDtoValidator()))
        {
            _notificationContext.AddNotifications(dto.ValidationResult);
            return new MemeDto();
        }

        var memeDomain = _mapper.Map<Meme>(dto);

        await _unitOfWork.MemeRepository.Create(memeDomain);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<MemeDto>(memeDomain);
    }
}