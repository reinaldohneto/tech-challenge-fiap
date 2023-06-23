using AutoMapper;
using Azure.Identity;
using Azure.Storage.Blobs;
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
    private readonly IConfiguration _configuration;

    public MemeService(NotificationContext notificationContext,
        IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<MemeDto> CreateMeme(MemeInputDto dto)
    {
        if (!dto.Validate(new MemeInputDtoValidator()))
        {
            _notificationContext.AddNotifications(dto.ValidationResult);
            return new MemeDto();
        }

        var memeDomain = _mapper.Map<Meme>(dto);

        if (!dto.IsVideo)
        {
            memeDomain.Link = await UploadImage(dto.Base64ImageOrVideoLink);
        }

        await _unitOfWork.MemeRepository.Create(memeDomain);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<MemeDto>(memeDomain);
    }

    public async Task<ICollection<MemeDto>> GetAllMemes()
    {
        var memes = await _unitOfWork
            .MemeRepository.GetAll();

        return _mapper.Map<ICollection<MemeDto>>(memes);
    }

    private async Task<string> UploadImage(string image)
    {
        var blobClient = new BlobClient(_configuration
            .GetConnectionString("ImagesBlob"),
            _configuration.GetValue<string>("ContainerBlobName"), Guid.NewGuid() + ".jpg");

        byte[] imageBytes = Convert.FromBase64String(image);

        using var stream = new MemoryStream(imageBytes);
        await blobClient.UploadAsync(stream);

        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<MemeDto> GetMemeById(string id)
    {

        var id_guid = Guid.Parse(id);

        var meme = await _unitOfWork
        .MemeRepository.GetById(id_guid);



        return _mapper.Map<MemeDto>(meme);
    }

    public async Task<bool> DeleteMemeById(string id)
    {

        var id_guid = Guid.Parse(id);

        var meme = await _unitOfWork
        .MemeRepository.Delete(id_guid);

        return meme;
    }

    public async Task UpdateMemeById(MemeInputUpdateDto dto)
    {

        var memeDomain = _mapper.Map<Meme>(dto);
        _unitOfWork
        .MemeRepository.Update(memeDomain);

        await _unitOfWork.CommitAsync();
    }
}
