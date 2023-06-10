namespace Fiap.TechChallenge.Api.Application.Dtos;

public record MemeUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsVideo { get; set; }
    public string Link { get; set; }
}