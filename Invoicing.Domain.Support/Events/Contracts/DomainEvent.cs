namespace Invoicing.Domain.Core.Events.Contracts;

using System;
using System.Collections.Generic;

public abstract class DomainEvent
{
    public string Type => GetType().Name;

    public DateTime Created { get; }

    public Dictionary<string, object> Args { get; }

    public string CorrelationId { get; set; }

    protected DomainEvent(string correlationId = "")
    {
        CorrelationId = correlationId;
        Created = DateTime.Now;
        Args = new Dictionary<string, object>();
    }

    public abstract void Flatten();
}