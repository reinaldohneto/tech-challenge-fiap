﻿using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace Fiap.TechChallenge.Api.Application.Dtos.Shared;

public abstract class BaseDto
{
    [JsonIgnore]
    public bool Valid { get; private set; }
    [JsonIgnore]
    public bool Invalid => !Valid;
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }

    public bool Validate<TDto>(AbstractValidator<TDto> validator) where TDto : BaseDto
    {
        ValidationResult = validator.Validate((TDto)this);
        return Valid = ValidationResult.IsValid;
    }
}