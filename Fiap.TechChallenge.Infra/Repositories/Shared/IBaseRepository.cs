using Fiap.TechChallenge.Domain.Entities.Shared;

namespace Fiap.TechChallenge.Infra.Repositories.Shared;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(Guid id);
    Task<TEntity> Create(TEntity entity);
    Task<ICollection<TEntity>> CreateMany(ICollection<TEntity> entities);
    void Update(TEntity entity);
    Task<bool> Delete(Guid id);
}