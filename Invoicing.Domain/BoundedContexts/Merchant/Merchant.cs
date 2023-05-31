namespace Invoicing.Domain.BoundedContexts.Merchant;

public class Merchant : Support.Contracts.Entities.Entity,
    Support.Contracts.Entities.IAggregateRoot
{
    /*
    Logo
    TradeChamberNumber
    TaxRegistrationNumber
    Address
    BankAccounts
    Contact
    */
    protected override FluentValidation.IValidator GetValidator()
    {
        throw new NotImplementedException();
    }
}