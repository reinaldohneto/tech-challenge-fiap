using Fiap.TechChallenge.Api.Application.Validators;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Fiap.TechChallenge.Api.Application.Dtos.Noticias;

public class NoticiaInputUpdateDto
{
    [JsonIgnore]
    public bool Valid { get; private set; }
    [JsonIgnore]
    public bool Invalid => !Valid;
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Chapeu { get; set; }
    public string Autor { get; set; }
}
