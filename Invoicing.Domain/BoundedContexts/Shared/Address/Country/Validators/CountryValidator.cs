namespace Invoicing.Domain.BoundedContexts.Shared.Address.Country.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.Currency.Validators;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class CountryValidator :
    ValueObjectValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(1, 30);
        RuleFor(c => c.Code)
            .NotEmpty()
            .Length(1, 3);
        RuleFor(c => c.Currency)
            .NotEmpty()
            .SetValidator(new CurrencyValidator());
    }
}