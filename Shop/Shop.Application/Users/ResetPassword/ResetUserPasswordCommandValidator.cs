using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ResetPassword;

public class ResetUserPasswordCommandValidator : AbstractValidator<ResetUserPasswordCommand>
{
    public ResetUserPasswordCommandValidator()
    {
        RuleFor(command => command.NewPassword)
            .MinimumLength(8)
            .WithMessage(ValidationMessages.MinLength("رمز عبور جدید", 8));
    }
}