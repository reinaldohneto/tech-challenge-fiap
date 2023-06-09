namespace Fiap.TechChallenge.Domain.Entities.Shared;

public abstract class Entity
{
    public Guid Id { get; set; } = new();
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.Now;
}