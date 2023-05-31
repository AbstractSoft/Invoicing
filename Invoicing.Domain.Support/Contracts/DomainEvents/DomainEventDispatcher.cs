namespace Invoicing.Domain.Support.Contracts.DomainEvents;

using Entities;

public class DomainEventDispatcher
{
    private readonly Dictionary<Type, List<object>> _eventHandlers;

    public DomainEventDispatcher()
    {
        _eventHandlers = new Dictionary<Type, List<object>>();
    }

    public void Dispatch<TEvent>(TEvent domainEvent)
        where TEvent : DomainEvent
    {
        var eventType = typeof(TEvent);
        if (!_eventHandlers.TryGetValue(eventType, out var handlers))
        {
            return;
        }

        foreach (var handler in handlers)
        {
            ((IDomainEventHandler<TEvent>)handler).Handle(domainEvent);
        }
    }

    public void Subscribe<TEvent, TEventHandler>()
        where TEvent : DomainEvent
        where TEventHandler : IDomainEventHandler<TEvent>
    {
        var eventType = typeof(TEvent);
        if (!_eventHandlers.ContainsKey(eventType))
        {
            _eventHandlers[eventType] = new List<object>();
        }

        _eventHandlers[eventType].Add(Activator.CreateInstance<TEventHandler>());
    }

    public void Unsubscribe<TEvent, TEventHandler>()
        where TEvent : DomainEvent
        where TEventHandler : IDomainEventHandler<TEvent>
    {
        var eventType = typeof(TEvent);

        if (!_eventHandlers.TryGetValue(eventType, out var handler))
        {
            return;
        }

        var handlerToRemove = handler.FirstOrDefault(h => h.GetType() == typeof(TEventHandler));
        if (handlerToRemove != null)
        {
            handler.Remove(handlerToRemove);
        }
    }
}