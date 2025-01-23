using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CurrentValidator:AbstractValidator<Current>
{
    public CurrentValidator()
    {
        RuleFor(p=>p.Name).NotEmpty();
        RuleFor(p=>p.Code).NotEmpty();
        RuleFor(p=>p.TaxNumber).NotEmpty();
        RuleFor(p => p.TaxDepartment).NotEmpty();

    }
}