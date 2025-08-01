using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
{
    public EditBannerCommandValidator()
    {
        RuleFor(command => command.Url)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("لینک"));
    }
}