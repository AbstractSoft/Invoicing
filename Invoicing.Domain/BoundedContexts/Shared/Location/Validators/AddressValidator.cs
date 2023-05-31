namespace Invoicing.Domain.BoundedContexts.Shared.Location.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class AddressValidator :
    ValueObjectValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(c => c.Name)
            .MaximumLength(30);

        RuleFor(c => c.Country)
            .NotEmpty()
            .SetValidator(
                new CountryValidator());

        RuleFor(c => c.County)
            .NotEmpty()
            .SetValidator(
                new CountyValidator());

        RuleFor(c => c.City)
            .NotEmpty()
            .SetValidator(
                new CityValidator());

        RuleFor(c => c.Street)
            .NotEmpty()
            .SetValidator(
                new StreetValidator());

        RuleFor(c => c.Building)
            .NotEmpty()
            .SetValidator(
                new BuildingValidator());
    }
}