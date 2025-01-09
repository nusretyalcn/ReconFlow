using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CompanyValidator: AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(p=>p.Name).NotEmpty().WithMessage("Şirket adı boş olamaz");
        RuleFor(p=>p.Name).MinimumLength(4).WithMessage("Şirket adı en az 4 karakter olmalı");
        RuleFor(p=>p.TaxNumber).NotEmpty().WithMessage("Vergi No boş olamaz");
        RuleFor(p=>p.Address).NotEmpty().WithMessage("Adres boş olamaz");
    }
}