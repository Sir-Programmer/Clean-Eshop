using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Coupons.Edit;

public class EditCouponCommandValidator : AbstractValidator<EditCouponCommand>
{
    public EditCouponCommandValidator()
    {
        RuleFor(c => c.Code)
            .MinimumLength(6)
            .WithMessage(ValidationMessages.MinLength("کد تخفیف", 6));

        RuleFor(c => c.DiscountAmount)
            .GreaterThanOrEqualTo(1)
            .WithMessage("مقدار تخفیف نامعتبر است");

        RuleFor(c => c.UsageLimit)
            .GreaterThanOrEqualTo(1)
            .WithMessage("مقدار لیمیت نامعتبر است");
    }
}