using Fiap.TechChallenge.Infra.Infrastructure;
using Fiap.TechChallenge.Infra.Repositories.Shared;
using NoticiaDomain = Fiap.TechChallenge.Domain.Entities.Noticias.Noticia;

namespace Fiap.TechChallenge.Infra.Repositories.Noticias;

public class NoticiaRepository : BaseRepository<NoticiaDomain>, INoticiaRepository
{
    public NoticiaRepository(SqlServerContext context) : base(context)
    {
    }
}