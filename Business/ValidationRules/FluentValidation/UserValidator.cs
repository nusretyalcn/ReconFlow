using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(p=>p.FirstName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p=>p.FirstName).MinimumLength(4).WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p=>p.Email).NotEmpty().WithMessage("Mail adresi adı boş olamaz");
        RuleFor(p=>p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
        
        
    }
}