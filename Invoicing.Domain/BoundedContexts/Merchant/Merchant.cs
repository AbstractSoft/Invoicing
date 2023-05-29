namespace Invoicing.Domain.BoundedContexts.Merchant;

public class Merchant : Invoicing.Domain.Support.Contracts.Entities.Entity,
    Invoicing.Domain.Support.Contracts.Entities.IAggregateRoot
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