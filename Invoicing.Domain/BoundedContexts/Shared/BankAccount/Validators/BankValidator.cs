namespace Invoicing.Domain.BoundedContexts.Shared.BankAccount.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;
using Location.Validators;

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