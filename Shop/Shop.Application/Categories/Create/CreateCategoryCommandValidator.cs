using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty().WithMessage(ValidationMessages.Required("عنوان"))
            .MinimumLength(3).WithMessage(ValidationMessages.MinLength("عنوان", 3));
        RuleFor(command => command.Slug)
            .NotEmpty().WithMessage(ValidationMessages.Required("Slug"))
            .MinimumLength(3).WithMessage(ValidationMessages.MinLength("Slug", 3));
    }
}