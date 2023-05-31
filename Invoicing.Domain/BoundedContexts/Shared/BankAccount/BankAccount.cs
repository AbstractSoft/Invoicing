namespace Invoicing.Domain.BoundedContexts.Shared.BankAccount;

using FluentValidation;
using Support.Contracts.ValueObjects;
using Validators;

[Serializable]
public class BankAccount : ValueObject
{
    private BankAccount()
    {
    }

    public static BankAccount MakeBankAccount(
        Bank bank,
        string account)
    {
        var bankAccount = new BankAccount
        {
            Bank = bank,
            Account = account
        };

        bankAccount.ValidateAndThrow();

        return bankAccount;
    }

    public Bank Bank { get; init; }
    public string Account { get; init; }

    protected override IValidator GetValidator()
    {
        return new BankAccountValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Bank;
        yield return Account;
    }
}