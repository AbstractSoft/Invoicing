namespace Invoicing.Domain.Support.Contracts.DomainEvents;

using Entities;

public abstract class DomainEvent
{
    protected DomainEvent(IAggregateRoot payload)
    {
        Payload = payload;
    }
    
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
    
    public IAggregateRoot Payload { get; }
}