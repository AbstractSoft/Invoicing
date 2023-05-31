namespace Invoicing.Domain.Support.Helpers;

public static class Constants
{
    public static T GetNullObject<T>()
        where T : Contracts.Entities.Entity
    {
        return Activator.CreateInstance<T, Guid>(Guid.Empty) ??
               throw new InvalidOperationException();
    }

    public static T GetNullObject<T>(params object[] parametersValues)
        where T : Contracts.ValueObjects.ValueObject
    {
        return (T)(System.Activator.CreateInstance(typeof(T), parametersValues) ??
                   throw new InvalidOperationException());
    }

    public static string GetNullString()
    {
        return string.Empty;
    }

    public static Uri GetNullUri()
    {
        return new Uri("about:blank");
    }
}