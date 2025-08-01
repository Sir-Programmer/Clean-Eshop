using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(command => command.PhoneNumber)
            .ValidPhoneNumber();

        RuleFor(command => command.Password)
            .MinimumLength(8)
            .WithMessage(ValidationMessages.MinLength("رمز عبور", 8));
    }
}