using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.EditProfile;

public class EditUserProfileCommandValidator : AbstractValidator<EditUserProfileCommand>
{
    public EditUserProfileCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام"));


        RuleFor(command => command.Family)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("نام خانوادگی"));
    }
}