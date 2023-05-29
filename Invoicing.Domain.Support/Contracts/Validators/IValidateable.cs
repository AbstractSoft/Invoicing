namespace Invoicing.Domain.Support.Contracts.Validators;

public interface IValidateable
{
    void ValidateAndThrow();
}