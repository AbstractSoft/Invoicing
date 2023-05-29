namespace Invoicing.Domain.BoundedContexts.Shared.Person.IDCard;

using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.County;
using Invoicing.Domain.BoundedContexts.Shared.Person.IDCard.Validators;
using Invoicing.Domain.Support.Contracts.ValueObjects;

[Serializable]
public sealed class IDCard : ValueObject
{
    private IDCard()
    {
    }

    public static IDCard MakeIDCard(County county, uint number, ulong personalIdentificationNumber)
    {
        var idCard = new IDCard
        {
            County = county,
            Number = number,
            PersonalIdentificationNumber = personalIdentificationNumber
        };

        idCard.ValidateAndThrow();

        return idCard;
    }

    public County County { get; init; }
    public uint Number { get; init; }
    public ulong PersonalIdentificationNumber { get; init; }

    public override string ToString() =>
        string.Format($"{County.Name}{Number}");

    protected override IValidator GetValidator()
    {
        return new IDCardValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return County;
        yield return Number;
        yield return PersonalIdentificationNumber;
    }
}