using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام"));
        
        
        RuleFor(command => command.Family)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام خانوادگی"));

        RuleFor(command => command.PhoneNumber)
            .ValidPhoneNumber();

        RuleFor(command => command.Email)
            .EmailAddress();

        RuleFor(command => command.Password)
            .MinimumLength(8)
            .WithMessage(ValidationMessages.MinLength("رمز عبور", 8));
    }
}