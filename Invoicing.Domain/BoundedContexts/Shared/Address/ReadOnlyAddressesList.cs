namespace Invoicing.Domain.BoundedContexts.Shared.Addresses;

using Invoicing.Domain.BoundedContexts.Shared.Address.Validators;

[Serializable]
public sealed class ReadOnlyAddressesList : Support.Contracts.ValueObjects.ReadOnlyValueObjectsList<Address.Address>
{
    public ReadOnlyAddressesList(IEnumerable<Address.Address> list)
        : base(list)
    {
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new ReadOnlyAddressesListValidator();
    }
}