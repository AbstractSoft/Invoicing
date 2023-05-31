namespace Invoicing.Domain.BoundedContexts.Customer.Contracts;

using System.Net.Mail;
using Shared.BankAccount;
using Shared.Location;

public abstract class Customer : Support.Contracts.Entities.Entity
{
    protected MailAddress MailAddress { get; set; }
    protected Address Address { get; set; }
    protected BankAccountsList BankAccounts { get; set; }

    // public void ChangeEmail(string email)
    // {
    //     if (Email == email)
    //     {
    //         return;
    //     }
    //
    //     Email = email;
    //
    //     Invoicing.Domain.Support.Events.DomainEvents.Raise(
    //         new eCommerce.Domain.Customers.Events.CustomerChangedEmail
    //         {
    //             Customer = this
    //         });
    // }
    //

    //
    // public ReadOnlyCollection<CreditCard> GetAvailableCreditCards()
    // {
    //     return CreditCards
    //         .FindAll(new eCommerce.Domain.Customers.Specifications.CreditCardAvailableSpec(DateTime.Today)
    //             .IsSatisfiedBy).AsReadOnly();
    // }
    //
    // public void AddCard(string nameOnCard, string cardNumber, DateTime expiry)
    // {
    //     var creditCard = CreditCard.Create(this, nameOnCard, cardNumber, expiry);
    //
    //     CreditCards.Add(creditCard);
    //
    //     Invoicing.Domain.Support.Events.DomainEvents
    //         .Raise(new eCommerce.Domain.Customers.Events.CreditCardAdded
    //         {
    //             CreditCard = creditCard
    //         });
    // }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Validators.CustomerValidator();
    }
}

//https://github.com/ardalis/CleanArchitecture/tree/main/src