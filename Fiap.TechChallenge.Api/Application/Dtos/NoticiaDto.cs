namespace Fiap.TechChallenge.Api.Application.Dtos;

public record NoticiaDto
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Chapeu { get; set; }
    public string Autor { get; set; }
}