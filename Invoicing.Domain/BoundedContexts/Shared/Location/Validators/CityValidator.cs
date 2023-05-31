namespace Invoicing.Domain.BoundedContexts.Shared.Location.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class CityValidator :
    ValueObjectValidator<City>
{
    public CityValidator()
    {
        RuleFor(c => c.County)
            .NotEmpty()
            .SetValidator(
                new CountyValidator());
        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(1, 30);
    }
}