using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Verifications.VerifyCode;

public class VerifyCodeCommandValidator : AbstractValidator<VerifyCodeCommand>
{
    public VerifyCodeCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .ValidPhoneNumber();
        RuleFor(x => x.Code)
            .NotEmpty()
            .Length(6).WithMessage("کد تایید باید 6 رقم داشته باشد");
    }
}