namespace Invoicing.Domain.BoundedContexts.Shared.BankAccount.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public class BankAccountValidator : ValueObjectValidator<BankAccount>
{
    public BankAccountValidator()
    {
        RuleFor(b => b.Bank)
            .NotEmpty()
            .SetValidator(new BankValidator());
        RuleFor(b => b.Account)
            .NotEmpty()
            .MaximumLength(24);
    }
}