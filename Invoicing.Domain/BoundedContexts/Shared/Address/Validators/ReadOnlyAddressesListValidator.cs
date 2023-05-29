namespace Invoicing.Domain.BoundedContexts.Shared.Address.Validators;

using Invoicing.Domain.BoundedContexts.Shared.Addresses;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;

[ExcludeFromCodeCoverage]
public sealed class ReadOnlyAddressesListValidator
    : Support.Contracts.Validators.ReadOnlyValueObjectsListValidator<ReadOnlyAddressesList, Address>
{
    public ReadOnlyAddressesListValidator()
    {
        RuleForEach(list => list)
            .NotNull()
            .SetValidator(new AddressValidator());
    }
}