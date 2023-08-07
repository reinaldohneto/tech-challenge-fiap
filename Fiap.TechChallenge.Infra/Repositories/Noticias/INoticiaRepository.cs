using Fiap.TechChallenge.Infra.Repositories.Shared;
using NoticiaDomain = Fiap.TechChallenge.Domain.Entities.Noticias.Noticia;

namespace Fiap.TechChallenge.Infra.Repositories.Noticias;

public interface INoticiaRepository : IBaseRepository<NoticiaDomain>
{

}