using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.SiteEntities.ShippingMethods.Create;

public class CreateShippingMethodValidator : AbstractValidator<CreateShippingMethodCommand>
{
    public CreateShippingMethodValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));

        RuleFor(command => command.Cost)
            .GreaterThanOrEqualTo(0)
            .WithMessage("هزینه ارسال نمیتواند کمتر از صفر باشد");
    }
}