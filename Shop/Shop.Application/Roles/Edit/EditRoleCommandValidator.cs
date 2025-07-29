using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Edit;

public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));
    }
}