
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Products.Edit;

public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));
        
        RuleFor(command => command.Slug)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("Slug"));
        
        RuleFor(command => command.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("توضیحات"));
    }
}