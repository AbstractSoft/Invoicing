namespace Invoicing.Domain.ContextMaps;

using Support.Contracts.Entities;

public class InvoiceContextMap
{
    private readonly Dictionary<string, object> _map;

    public InvoiceContextMap()
    {
        _map = new Dictionary<string, object>();
    }

    public void Add(string key, object value)
    {
        _map[key] = value;
    }

    public T Get<T>(string key) 
        where T: IAggregateRoot
    {
        if (_map.TryGetValue(key, out var value))
        {
            return (T)value;
        }

        return default(T);
    }
}