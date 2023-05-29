namespace Invoicing.Domain.BoundedContexts.Person;

using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address;
using Invoicing.Domain.BoundedContexts.Shared.Person.Validators;
using Invoicing.Domain.Support.Contracts.Entities;

[Serializable]
public sealed class Person : Entity
{
    private Person()
        : base() { }

    private Person(Guid objectId)
        : base(objectId) { }

    public static Person MakePerson(
        string firstName,
        string lastName,
        Shared.Person.IDCard.IDCard idCard,
        Address address,
        Invoicing.Domain.BoundedContexts.Shared.Bank.BankAccount bankAccount)
    {
        return MakePerson(Guid.NewGuid(), firstName, lastName, idCard, address, bankAccount);
    }

    public static Person MakePerson(
        Guid objectId,
        string firstName,
        string lastName,
        Shared.Person.IDCard.IDCard idCard,
        Address address,
        Invoicing.Domain.BoundedContexts.Shared.Bank.BankAccount bankAccount
    )
    {
        var person = new Person(objectId)
        {
            FirstName = firstName,
            LastName = lastName,
            IDCard = idCard,
            Address = address,
            BankAccount = bankAccount
        };

        person.ValidateAndThrow();

        return person;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Shared.Person.IDCard.IDCard IDCard { get; private set; }
    public Address Address { get; private set; }
    public Invoicing.Domain.BoundedContexts.Shared.Bank.BankAccount BankAccount { get; private set; }

    protected override IValidator GetValidator()
    {
        return new PersonValidator();
    }
}

