using Fiap.TechChallenge.Infra.Repositories.Shared;
using MemeDomain = Fiap.TechChallenge.Domain.Entities.Memes.Meme;

namespace Fiap.TechChallenge.Infra.Repositories.Meme;

public interface IMemeRepository : IBaseRepository<MemeDomain>
{

}