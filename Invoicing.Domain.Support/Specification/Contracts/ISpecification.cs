namespace Invoicing.Domain.Support.Specification.Contracts;

public interface ISpecification<T>
{
    System.Linq.Expressions.Expression<Func<T, bool>> SpecExpression { get; }
    bool IsSatisfiedBy(T obj);
}