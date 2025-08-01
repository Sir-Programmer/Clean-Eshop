using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));
        
        RuleFor(command => command.Slug)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("Slug"));
        
        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("توضیحات"));

        RuleFor(command => command.ImageFile)
            .JustImageFile();
    }
}