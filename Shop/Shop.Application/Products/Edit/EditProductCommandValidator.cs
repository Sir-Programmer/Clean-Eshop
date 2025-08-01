
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Edit;

public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
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