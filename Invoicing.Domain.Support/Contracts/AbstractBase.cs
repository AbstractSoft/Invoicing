namespace Invoicing.Domain.Support.Contracts;

public abstract class AbstractBase : Invoicing.Domain.Support.Contracts.Validators.IValidateable
{
    public virtual void ValidateAndThrow()
    {
        var validationResult = GetValidator()
            .Validate(new FluentValidation.ValidationContext<object>(this));

        if (validationResult?.IsValid == false)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
    }

    public T Copy<T>() where T : AbstractBase
    {
        var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<T, T>()
            .ConstructUsing(x => Activator.CreateInstance<T>()));
        config.AssertConfigurationIsValid();

        var mapper = config.CreateMapper();

        return mapper.Map<T, T>((T)this);
    }
    
    protected abstract FluentValidation.IValidator GetValidator();

    public static string NullString => string.Empty;
}