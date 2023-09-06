namespace Invoicing.Domain.BoundedContexts.Person;

using FluentValidation;
using Support.Contracts.Entities;
using Shared.BankAccount;
using Shared.Location;
using Shared.Name;
using Validators;

[Serializable]
public sealed class Person : Entity, IAggregateRoot
{
    private Name _name;
    private IDCard.IDCard _idCard;
    private Address _address;
    private BankAccount _bankAccount;
    
    private Person() { }

    private Person(Guid objectId)
        : base(objectId) { }

    public static Person MakePerson(
        Name name,
        IDCard.IDCard idCard,
        Address address,
        BankAccount bankAccount)
    {
        return MakePerson(Guid.NewGuid(), name, idCard, address, bankAccount);
    }

    public static Person MakePerson(
        Guid objectId,
        Name name,
        IDCard.IDCard idCard,
        Address address,
        BankAccount bankAccount
    )
    {
        var person = new Person(objectId)
        {
            Name = name,
            IDCard = idCard,
            Address = address,
            BankAccount = bankAccount
        };

        person.ValidateAndThrow();

        return person;
    }

    public Name Name
    {
        get => _name;
        set
        {
            _name = value;
            
            ValidateAndThrow();
            
            //Invoicing.Domain.Support.Events.DomainEvents.Raise(
            //         new eCommerce.Domain.Customers.Events.PersonChanged
            //         {
            //             Person = this
            //         });
        }
    }

    public IDCard.IDCard IDCard
    {
        get => _idCard;
        set
        {
            _idCard = value;
            
            ValidateAndThrow();
            
            //Invoicing.Domain.Support.Events.DomainEvents.Raise(
            //         new eCommerce.Domain.Customers.Events.PersonChanged
            //         {
            //             Person = this
            //         });
        }
    }

    public Address Address
    {
        get => _address;
        set
        {
            _address = value; 
            
            ValidateAndThrow();
            
            //Invoicing.Domain.Support.Events.DomainEvents.Raise(
            //         new eCommerce.Domain.Customers.Events.PersonChanged
            //         {
            //             Person = this
            //         });
        }
    }

    public BankAccount BankAccount
    {
        get => _bankAccount;
        set
        {
            _bankAccount = value;
            
            ValidateAndThrow();
            
            //Invoicing.Domain.Support.Events.DomainEvents.Raise(
            //         new eCommerce.Domain.Customers.Events.PersonChanged
            //         {
            //             Person = this
            //         });
        }
    }

    protected override IValidator GetValidator()
    {
        return new PersonValidator();
    }
}

