namespace Invoicing.Domain.BoundedContexts.Shared.Address;

using Invoicing.Domain.BoundedContexts.Shared.Address.Validators;
using Invoicing.Domain.Support.Contracts.ValueObjects;

public sealed class Address : ValueObject
{
    private Address()
    {
    }

    public static Address MakeAddress(
        Country.Country country,
        County.County county,
        City.City city,
        Street.Street street,
        Building.Building building,
        string name = "")
    {
        var address = new Address
        {
            Name = name,
            Country = country,
            County = county,
            City = city,
            Street = street,
            Building = building
        };

        address.ValidateAndThrow();

        return address;
    }

    public string Name { get; init; }
    public Country.Country Country { get; init; }
    public County.County County { get; init; }
    public City.City City { get; init; }
    public Street.Street Street { get; init; }
    public Building.Building Building { get; init; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new AddressValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Country;
        yield return County;
        yield return City;
        yield return Street;
        yield return Building;
    }
}