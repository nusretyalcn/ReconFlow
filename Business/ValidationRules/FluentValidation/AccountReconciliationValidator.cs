using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class AccountReconciliationValidator: AbstractValidator<AccountReconciliation>
{
    public AccountReconciliationValidator()
    {
        RuleFor(p=>p.ReconciliationNo).NotEmpty();
        RuleFor(p=>p.ReconciliationNo).MaximumLength(7);
        RuleFor(p=>p.TotalDebit).NotEmpty();
        RuleFor(p=>p.TotalCredit).NotEmpty();
        RuleFor(p=>p.Balance).NotEmpty();
    }
}