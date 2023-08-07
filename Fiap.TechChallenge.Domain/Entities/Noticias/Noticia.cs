using Fiap.TechChallenge.Domain.Entities.Shared;

namespace Fiap.TechChallenge.Domain.Entities.Noticias;

public class Noticia : Entity
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Chapeu { get; set; }
    public string Autor { get; set; }
    public DateTime DataPublicacao { get; set; }
}