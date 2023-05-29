namespace Invoicing.Domain.BoundedContexts.Shared.Address.Street;

using Invoicing.Domain.BoundedContexts.Shared.Address.Street.Validators;
using Invoicing.Domain.Support.Contracts.ValueObjects;

[Serializable]
public sealed class Street : ValueObject
{
    private Street()
    {
    }

    public static Street MakeStreet(
        City.City city,
        string name,
        Prefix prefix = Prefix.Strada,
        uint postCode = default)
    {
        var street = new Street
        {
            City = city,
            Name = name,
            Prefix = prefix,
            PostCode = postCode
        };

        street.ValidateAndThrow();

        return street;
    }

    public City.City City { get; init; }
    public string Name { get; init; }
    public Prefix Prefix { get; init; }
    public uint PostCode { get; init; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new StreetValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return City;
        yield return Name;
        yield return Prefix;
        yield return PostCode;
    }
}