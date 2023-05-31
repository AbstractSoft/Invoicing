namespace Invoicing.Domain.BoundedContexts.Company;

using Support.Contracts.Entities;

public class Company : Entity, IAggregateRoot
{
		public Company()
		{
		}

		protected override FluentValidation.IValidator GetValidator()
		{
			throw new NotImplementedException();
		}
}

/*
Logo
TradeChamberNumber
TaxRegistrationNumber
Address
BankAccounts
Contact
*/