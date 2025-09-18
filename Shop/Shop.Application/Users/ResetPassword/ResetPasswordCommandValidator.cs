using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(command => command.NewPassword)
            .MinimumLength(8)
            .WithMessage(ValidationMessages.MinLength("رمز عبور جدید", 8));
    }
}