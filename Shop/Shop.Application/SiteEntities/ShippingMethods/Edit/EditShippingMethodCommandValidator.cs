using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommandValidator : AbstractValidator<EditShippingMethodCommand>
{
    public EditShippingMethodCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.Required("عنوان"));

        RuleFor(command => command.Cost)
            .GreaterThanOrEqualTo(0)
            .WithMessage("هزینه ارسال نمیتواند کمتر از صفر باشد");
    }
}