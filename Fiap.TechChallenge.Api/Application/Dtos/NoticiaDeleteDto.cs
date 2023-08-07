using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Fiap.TechChallenge.Api.Application.Dtos;

public class NoticiaDeleteDto
{
    [JsonIgnore]
    public bool Valid { get; private set; }
    [JsonIgnore]
    public bool Invalid => !Valid;
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }


    public bool Result { get; set; }

}