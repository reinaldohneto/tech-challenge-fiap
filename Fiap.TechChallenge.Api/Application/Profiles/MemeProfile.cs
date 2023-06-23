using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Domain.Entities.Memes;

namespace Fiap.TechChallenge.Api.Application.Profiles;

public class MemeProfile : Profile
{
    public MemeProfile()
    {
        CreateMap<MemeInputDto, Meme>()
            .ForMember(m => m.Link, cfg => 
                cfg.MapFrom(src => src.IsVideo ? 
                    src.Base64ImageOrVideoLink : string.Empty));
        CreateMap<Meme, MemeDto>();
    }
}