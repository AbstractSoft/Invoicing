namespace Invoicing.Domain.Support.Contracts.Validators;

using Entities;

public abstract class EntityValidator<T> : FluentValidation.AbstractValidator<T>
    where T : Entity
{
    protected new FluentValidation.IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(
        System.Linq.Expressions.Expression<Func<T, TProperty>> expression)
    {
        FluentValidation.ValidatorOptions.Global.DisplayNameResolver = (type, member, arg3) =>
        {
            var entity = (Entity)Convert.ChangeType(type, typeof(Entity));

            return $"{type.Name}::[{entity.ObjectId}]::{member?.Name}";
        };

        return base.RuleFor(expression);
    }
}