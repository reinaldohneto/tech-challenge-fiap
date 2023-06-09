using Fiap.TechChallenge.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.TechChallenge.Infra.Maps.Shared;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.CreationDate)
            .HasColumnName("CreationDate")
            .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.UpdateDate)
            .HasColumnName("UpdateDate")
            .HasDefaultValueSql("GETDATE()");
    }
}