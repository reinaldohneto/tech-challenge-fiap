using Fiap.TechChallenge.Domain.Entities.Shared;
using Fiap.TechChallenge.Infra.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Fiap.TechChallenge.Infra.Repositories.Shared;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
{
    internal DbSet<TEntity> DbSet;
    internal SqlServerContext Context;

    protected BaseRepository(SqlServerContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAll()
    {
        return DbSet
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TEntity?> GetById(int id)
        => await DbSet.FindAsync(id);

    public async Task<TEntity> Create(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public async Task<ICollection<TEntity>> CreateMany(ICollection<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
        return entities;
    }

    public void Update(TEntity entity)
        => DbSet.Update(entity);

    public async Task<bool> Delete(int id)
    {
        var register = await DbSet.FindAsync(id);

        if (register == null) return false;
        
        DbSet.Remove(register);
        return true;
    }
}