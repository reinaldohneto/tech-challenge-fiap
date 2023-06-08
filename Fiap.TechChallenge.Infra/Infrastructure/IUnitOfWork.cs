using Fiap.TechChallenge.Infra.Repositories.Meme;

namespace Fiap.TechChallenge.Infra.Infrastructure;

public interface IUnitOfWork
{
    Task CommitAsync();

    IMemeRepository MemeRepository { get; }
}