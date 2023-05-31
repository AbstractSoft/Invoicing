namespace Invoicing.Domain.BoundedContexts.Shared.BankAccount.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public class BankAccountsListValidator : ValueObjectsListValidator<BankAccountsList, BankAccount>
{
    public BankAccountsListValidator()
    {
        RuleForEach(list => list)
            .NotEmpty()
            .SetValidator(new BankAccountValidator());
    }
}