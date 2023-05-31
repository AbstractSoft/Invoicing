namespace Invoicing.Domain.BoundedContexts.Shared.BankAccount;

using Location;
using Support.Contracts.ValueObjects;
using Validators;

[Serializable]
public class Bank : ValueObject
{
    private Bank()
    {
    }

    public static Bank MakeBank(
        string name,
        Address address)
    {
        var bank = new Bank
        {
            Name = name,
            Address = address
        };

        bank.ValidateAndThrow();

        return bank;
    }

    public string Name { get; init; }
    public Address Address { get; init; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new BankValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Address;
    }
}