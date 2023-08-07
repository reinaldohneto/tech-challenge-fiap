using Fiap.TechChallenge.Infra.Repositories.Noticias;

namespace Fiap.TechChallenge.Infra.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlServerContext _context;

    public UnitOfWork(SqlServerContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
        => await _context.SaveChangesAsync();

    public INoticiaRepository NoticiaRepository
        => new NoticiaRepository(_context);
}