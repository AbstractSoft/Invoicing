namespace Invoicing.Domain.BoundedContexts.Shared.Location;

using Validators;

[Serializable]
public sealed class ReadOnlyAddressesList : Support.Contracts.ValueObjects.ReadOnlyValueObjectsList<Address>
{
    public ReadOnlyAddressesList(IEnumerable<Address> list)
        : base(list)
    {
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new ReadOnlyAddressesListValidator();
    }
}