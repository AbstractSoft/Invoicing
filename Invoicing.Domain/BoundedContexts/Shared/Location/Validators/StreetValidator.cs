namespace Invoicing.Domain.BoundedContexts.Shared.Location.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
internal sealed class StreetValidator : ValueObjectValidator<Street>
{
    public StreetValidator()
    {
        RuleFor(c => c.City)
            .NotEmpty()
            .SetValidator(new CityValidator());

        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(1, 30);
    }
}