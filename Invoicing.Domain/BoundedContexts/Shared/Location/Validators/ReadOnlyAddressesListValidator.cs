namespace Invoicing.Domain.BoundedContexts.Shared.Location.Validators;

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