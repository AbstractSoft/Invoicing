namespace Invoicing.Domain.Support.Specification.Contracts;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    private Func<T, bool> compiledExpression;

    private Func<T, bool> CompiledExpression
    {
        get { return compiledExpression ??= SpecExpression.Compile(); }
    }

    public abstract System.Linq.Expressions.Expression<Func<T, bool>> SpecExpression { get; }

    public bool IsSatisfiedBy(T obj)
    {
        return CompiledExpression(obj);
    }
}