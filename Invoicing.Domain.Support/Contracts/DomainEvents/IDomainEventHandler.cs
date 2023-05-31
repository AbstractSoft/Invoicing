namespace Invoicing.Domain.Support.Contracts.DomainEvents;

public interface IDomainEventHandler<in TEvent> 
    where TEvent : DomainEvent
{
    void Handle(TEvent domainEvent);
}