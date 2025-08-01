using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
{
    public CreateBannerCommandValidator()
    {
        RuleFor(command => command.Url)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("لینک"));
    }
}