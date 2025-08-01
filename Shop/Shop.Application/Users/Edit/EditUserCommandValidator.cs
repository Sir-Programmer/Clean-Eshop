using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام"));
        
        
        RuleFor(command => command.Family)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام خانوادگی"));

        RuleFor(command => command.PhoneNumber)
            .ValidPhoneNumber();

        RuleFor(command => command.Email)
            .EmailAddress();
    }
}