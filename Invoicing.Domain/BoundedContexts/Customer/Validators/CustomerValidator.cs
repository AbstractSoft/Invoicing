using System.Diagnostics.CodeAnalysis;

namespace Invoicing.Domain.BoundedContexts.Customer.Validators;

using Contracts;

[ExcludeFromCodeCoverage]
public class CustomerValidator : FluentValidation.AbstractValidator<Customer>
{
}