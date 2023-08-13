using AutoMapper;
using Fiap.TechChallenge.Api.Application.Dtos.Noticias;
using Fiap.TechChallenge.Domain.Entities.Noticias;

namespace Fiap.TechChallenge.Api.Application.Profiles;

public class NoticiaProfile : Profile
{
    public NoticiaProfile()
    {
        CreateMap<NoticiaInputDto, Noticia>();
        CreateMap<Noticia, NoticiaDto>();
        CreateMap<Noticia, NoticiaUpdateDto>();
        CreateMap<NoticiaInputUpdateDto, Noticia>();
    }
}