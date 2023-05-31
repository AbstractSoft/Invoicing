namespace Invoicing.Domain.Support.Specification;

public class Or<T> : Contracts.SpecificationBase<T>
{
    private readonly Contracts.ISpecification<T> left;
    private readonly Contracts.ISpecification<T> right;

    public Or(Contracts.ISpecification<T> left,
        Contracts.ISpecification<T> right)
    {
        this.left = left;
        this.right = right;
    }

    // OrSpecification
    public override System.Linq.Expressions.Expression<Func<T, bool>> SpecExpression
    {
        get
        {
            var objParam = System.Linq.Expressions.Expression.Parameter(typeof(T), "obj");

            var newExpr = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                System.Linq.Expressions.Expression.OrElse(
                    System.Linq.Expressions.Expression.Invoke(left.SpecExpression, objParam),
                    System.Linq.Expressions.Expression.Invoke(right.SpecExpression, objParam)
                ),
                objParam
            );

            return newExpr;
        }
    }
}