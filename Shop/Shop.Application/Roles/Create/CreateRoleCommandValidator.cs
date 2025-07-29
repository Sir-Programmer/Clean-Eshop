using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));
    }
}