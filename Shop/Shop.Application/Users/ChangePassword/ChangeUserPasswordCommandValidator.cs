using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChangePassword;

public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
{
    public ChangeUserPasswordCommandValidator()
    {
        RuleFor(command => command.Password)
            .MinimumLength(8)
            .WithMessage(ValidationMessages.MinLength("رمز عبور جدید", 8));
        
        RuleFor(command => command.CurrentPassword)
            .MinimumLength(8)
            .WithMessage(ValidationMessages.MinLength("رمز عبور فعلی", 8));
    }
}