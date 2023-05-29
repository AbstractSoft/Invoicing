namespace Invoicing.Domain.Core.Events;

using System;
using System.Collections.Generic;

public struct DomainEventRecord
{
    public string Type { get; set; }
    public List<KeyValuePair<string, string>> Args { get; set; }
    public string CorrelationId { get; set; }
    public DateTime Created { get; set; }
}