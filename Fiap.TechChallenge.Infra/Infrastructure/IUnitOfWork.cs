using Fiap.TechChallenge.Infra.Repositories.Noticias;

namespace Fiap.TechChallenge.Infra.Infrastructure;

public interface IUnitOfWork
{
    Task CommitAsync();

    INoticiaRepository NoticiaRepository { get; }
}