namespace Invoicing.Domain.BoundedContexts.Shared.BankAccount;

using FluentValidation;
using Validators;

[Serializable]
public sealed class BankAccountsList
    : Support.Contracts.ValueObjects.ValueObjectsList<BankAccount>
{
    protected override IValidator GetValidator()
    {
        return new BankAccountsListValidator();
    }
}