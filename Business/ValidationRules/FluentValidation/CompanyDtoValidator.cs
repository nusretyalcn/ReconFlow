using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CompanyDtoValidator: AbstractValidator<CompanyDto>
{
    public CompanyDtoValidator()
    {
        RuleFor(p=>p.Companies).NotEmpty().WithMessage("Şirket Listesi boş olamaz");
        RuleForEach(p=>p.Companies).SetValidator(new CompanyValidator());
        
        RuleFor(p=>p.UserId).NotEmpty().WithMessage("Kullanıcı Id'si boş olamaz");
    }
}