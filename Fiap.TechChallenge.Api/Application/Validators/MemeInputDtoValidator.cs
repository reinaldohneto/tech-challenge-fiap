using Fiap.TechChallenge.Api.Application.Dtos;
using FluentValidation;

namespace Fiap.TechChallenge.Api.Application.Validators;

public class MemeInputDtoValidator : AbstractValidator<MemeInputDto>
{
    public MemeInputDtoValidator()
    {
        RuleFor(m => m.Name)
            .MaximumLength(50);

        RuleFor(m => m.Description)
            .MinimumLength(1);

        RuleFor(m => m.Link)
            .Length(10, 250);
    }
}