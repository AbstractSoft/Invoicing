namespace Invoicing.Domain.Core.Events.Contracts;

public interface IHandle<in T> 
    where T : Invoicing.Domain.Core.Events.Contracts.DomainEvent
{
    void Handle(T args); 
}