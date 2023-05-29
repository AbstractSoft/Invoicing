namespace Invoicing.Domain.Support.Contracts.Validators;

public class ValueObjectValidator<T> : FluentValidation.AbstractValidator<T>
    where T : Invoicing.Domain.Support.Contracts.ValueObjects.ValueObject
{
    protected new FluentValidation.IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(
        System.Linq.Expressions.Expression<Func<T, TProperty>> expression)
    {
        FluentValidation.ValidatorOptions.Global.DisplayNameResolver = (type, member, arg3) => 
            $"{type.Name}::{member?.Name}";

        return base.RuleFor(expression);
    }
}