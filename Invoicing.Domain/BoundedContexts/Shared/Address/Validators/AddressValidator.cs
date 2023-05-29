namespace Invoicing.Domain.BoundedContexts.Shared.Address.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.Building.Validators;
using Invoicing.Domain.BoundedContexts.Shared.Address.City.Validators;
using Invoicing.Domain.BoundedContexts.Shared.Address.Country.Validators;
using Invoicing.Domain.BoundedContexts.Shared.Address.County.Validators;
using Invoicing.Domain.BoundedContexts.Shared.Address.Street.Validators;
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