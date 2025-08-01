using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));
        
        RuleFor(command => command.Url)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("لینک"));

        RuleFor(command => command.ImageFile)
            .JustImageFile()
            .MaxFileSize(5);
    }
}