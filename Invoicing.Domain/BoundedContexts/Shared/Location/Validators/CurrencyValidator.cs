namespace Invoicing.Domain.BoundedContexts.Shared.Location.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class CurrencyValidator :
    ValueObjectValidator<Currency>
{
    public CurrencyValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(1, 30);
        RuleFor(c => c.Symbol)
            .NotEmpty()
            .Length(1, 3);
    }
}