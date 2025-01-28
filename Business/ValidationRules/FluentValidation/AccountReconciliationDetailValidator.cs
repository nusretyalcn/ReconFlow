using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class AccountReconciliationDetailValidator: AbstractValidator<AccountReconciliationDetail>
{
    public AccountReconciliationDetailValidator()
    {

        RuleFor(p=>p.AccountReconciliationId).NotEmpty();
        RuleFor(p=>p.Description).NotEmpty();
        RuleFor(p=>p.Description).MaximumLength(100);
        
    }
}