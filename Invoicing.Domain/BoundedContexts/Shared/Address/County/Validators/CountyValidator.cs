namespace Invoicing.Domain.BoundedContexts.Shared.Address.County.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.Country.Validators;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class CountyValidator :
    ValueObjectValidator<County>
{
    public CountyValidator()
    {
        RuleFor(c => c.Country)
            .NotEmpty()
            .SetValidator(
                new CountryValidator());
        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(1, 30);
        RuleFor(c => c.Code)
            .NotEmpty()
            .Length(1, 3);
    }
}