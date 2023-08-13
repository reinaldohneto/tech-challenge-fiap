using Fiap.TechChallenge.Api.Application.Validators;
using FluentValidation.Results;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Fiap.TechChallenge.Api.Application.Dtos.Shared;

namespace Fiap.TechChallenge.Api.Application.Dtos.Noticias;

public class NoticiaInputDto : BaseDto
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Chapeu { get; set; }
    public string Autor { get; set; }
}