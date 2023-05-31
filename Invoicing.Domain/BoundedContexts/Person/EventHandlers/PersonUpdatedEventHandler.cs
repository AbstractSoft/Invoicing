namespace Invoicing.Domain.BoundedContexts.Person.EventHandlers;

using Events;
using Support.Contracts.DomainEvents;

public class PersonUpdatedEventHandler : IDomainEventHandler<PersonUpdatedEvent>
{
    public void Handle(PersonUpdatedEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}