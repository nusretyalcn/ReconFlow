using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CurrentAccountValidator: AbstractValidator<CurrentAccount>
{
    public CurrentAccountValidator()
    {
        RuleFor(p=>p.Code).NotEmpty();
        RuleFor(p => p.Code).MinimumLength(4);
    }
}