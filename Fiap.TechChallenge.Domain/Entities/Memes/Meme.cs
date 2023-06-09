using Fiap.TechChallenge.Domain.Entities.Shared;

namespace Fiap.TechChallenge.Domain.Entities.Memes;

public class Meme : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsVideo { get; set; }
    public string Link { get; set; }
}