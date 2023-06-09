using Fiap.TechChallenge.Infra.Infrastructure;
using Fiap.TechChallenge.Infra.Repositories.Shared;
using MemeDomain = Fiap.TechChallenge.Domain.Entities.Memes.Meme;

namespace Fiap.TechChallenge.Infra.Repositories.Meme;

public class MemeRepository : BaseRepository<MemeDomain>, IMemeRepository
{
    public MemeRepository(SqlServerContext context) : base(context)
    {
    }
}