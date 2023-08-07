using Fiap.TechChallenge.Api.Application.Validators;
using FluentValidation.Results;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Fiap.TechChallenge.Api.Application.Dtos;

public class NoticiaInputDto
{
    [JsonIgnore]
    public bool Valid { get; private set; }
    [JsonIgnore]
    public bool Invalid => !Valid;
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }

    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Chapeu { get; set; }
    public string Autor { get; set; }

    public bool Validate(NoticiaInputDtoValidator validator)
    {
        ValidationResult = validator.Validate(this);
        return Valid = ValidationResult.IsValid;
    }
}