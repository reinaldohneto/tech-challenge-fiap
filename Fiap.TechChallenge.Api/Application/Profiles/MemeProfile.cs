using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Domain.Entities.Memes;

namespace Fiap.TechChallenge.Api.Application.Profiles;

public class MemeProfile : Profile
{
    public MemeProfile()
    {
        CreateMap<MemeInputDto, Meme>();
        CreateMap<Meme, MemeDto>();
        CreateMap<Meme, MemeUpdateDto>();
        CreateMap<MemeInputUpdateDto, Meme>();
    }
}