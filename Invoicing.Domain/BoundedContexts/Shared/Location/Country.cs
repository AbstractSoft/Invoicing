namespace Invoicing.Domain.BoundedContexts.Shared.Location;

using Validators;

[Serializable]
public sealed class Country : Support.Contracts.ValueObjects.ValueObject
{
    private Country()
    {
    }

    public static Country MakeCountry(
        string name,
        string code,
        Currency currency)
    {
        var country = new Country
        {
            Name = name,
            Code = code,
            Currency = currency
        };

        country.ValidateAndThrow();

        return country;
    }

    public string Name { get; init; }

    public string Code { get; init; }

    public Currency Currency { get; init; }

    public static Country NullObject => new()
    {
        Name = "",
        Code = "",
        Currency = Currency.NullObject
    };

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Code;
        yield return Currency;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new CountryValidator();
    }
}