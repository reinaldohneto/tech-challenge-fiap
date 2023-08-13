using Fiap.TechChallenge.Api.Application.Dtos.Noticias;
using FluentValidation;

namespace Fiap.TechChallenge.Api.Application.Validators;

public class NoticiaInputDtoValidator : AbstractValidator<NoticiaInputDto>
{
    public NoticiaInputDtoValidator()
    {
        RuleFor(m => m.Titulo)
            .MaximumLength(100);

        RuleFor(m => m.Descricao)
            .MinimumLength(1);

        RuleFor(m => m.Chapeu)
            .MaximumLength(250);

        RuleFor(m => m.Autor)
            .MaximumLength(100);
    }
}