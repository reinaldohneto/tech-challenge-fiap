using Fiap.TechChallenge.Api.Application.Validators;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Fiap.TechChallenge.Api.Application.Dtos;

public class MemeInputDto
{
    [JsonIgnore]
    public bool Valid { get; private set; }
    [JsonIgnore]
    public bool Invalid => !Valid;
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsVideo { get; set; }
    public string Link { get; set; }



    public bool Validate(MemeInputDtoValidator validator)
    {
        ValidationResult = validator.Validate(this);
        return Valid = ValidationResult.IsValid;
    }
}