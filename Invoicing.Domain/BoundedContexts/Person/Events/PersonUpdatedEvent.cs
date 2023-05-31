namespace Invoicing.Domain.BoundedContexts.Person.Events;

using Support.Contracts.DomainEvents;
using Support.Contracts.Entities;

public class PersonUpdatedEvent : DomainEvent
{
    public PersonUpdatedEvent(IAggregateRoot payload)
        : base(payload)
    {
    }
}