namespace Invoicing.Domain.BoundedContexts.Shared.Address.City.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.County.Validators;
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