namespace Invoicing.Domain.BoundedContexts.Shared.Bank.Validators;

using System.Diagnostics.CodeAnalysis;
using Address.Validators;
using FluentValidation;
using Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public class BankValidator : ValueObjectValidator<Bank>
{
    public BankValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(b => b.Address)
            .NotEmpty()
            .SetValidator(new AddressValidator());
    }
}