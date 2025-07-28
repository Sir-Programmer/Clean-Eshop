using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
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