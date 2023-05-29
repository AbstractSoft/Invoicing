namespace Invoicing.Domain.BoundedContexts.Shared.Person.IDCard.Validators;

using System;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.County.Validators;
using Invoicing.Domain.Support.Contracts.Validators;
using static System.Runtime.InteropServices.JavaScript.JSType;

[ExcludeFromCodeCoverage]
public sealed class IDCardValidator : ValueObjectValidator<IDCard>
{
    private const ulong cntrl = 279146358279;

    public IDCardValidator()
    {
        RuleFor(c => c.County)
            .NotEmpty()
            .SetValidator(new CountyValidator());
        RuleFor(c => c.Number.ToString())
            .NotEmpty()
            .Length(6);
        RuleFor(c => c.PersonalIdentificationNumber.ToString())
            .NotEmpty()
            .Length(13);
        RuleFor(c => c.PersonalIdentificationNumber)
            .Must(ValidatePersonalIdentificationNumber)
            .WithMessage(MakeInvalidPersonalIdentificationNumberMessage);
    }

    private bool ValidatePersonalIdentificationNumber(ulong personalIdentificationNumber)
    {
        return true; // TODO: implement CNP validation
    }

    private string MakeInvalidPersonalIdentificationNumberMessage(IDCard idCard)
    {
        return string.Format($"The Personal Identification Number {idCard.PersonalIdentificationNumber} is not valid");
    }
}