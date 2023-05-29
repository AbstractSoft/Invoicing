namespace Invoicing.Domain.BoundedContexts.Shared.Address.Currency;

[Serializable]
public sealed class Currency : Support.Contracts.ValueObjects.ValueObject
{
    private Currency()
    {
    }

    public static Currency MakeCurrency(
        string name,
        string symbol)
    {
        var currency = new Currency
        {
            Name = name,
            Symbol = symbol
        };

        currency.ValidateAndThrow();

        return currency;
    }

    public string Name { get; init; }
    public string Symbol { get; init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Symbol;
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Validators.CurrencyValidator();
    }
}