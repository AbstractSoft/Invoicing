namespace Invoicing.Domain.BoundedContexts.Shared.Person.Validators;

using System.Diagnostics.CodeAnalysis;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class PersonValidator : EntityValidator<Invoicing.Domain.BoundedContexts.Person.Person>
{
    public PersonValidator()
    {
    }
}