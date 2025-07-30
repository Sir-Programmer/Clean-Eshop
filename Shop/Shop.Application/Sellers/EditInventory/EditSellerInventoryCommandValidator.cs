using FluentValidation;

namespace Shop.Application.Sellers.EditInventory;

public class EditSellerInventoryCommandValidator : AbstractValidator<EditSellerInventoryCommand>
{
    public EditSellerInventoryCommandValidator()
    {
        RuleFor(command => command.Count)
            .GreaterThanOrEqualTo(0)
            .WithMessage("تعداد مجودی نمیتواند کمتر از 0 باشد");

        RuleFor(command => command.Price)
            .GreaterThanOrEqualTo(1000)
            .WithMessage("مبلغ وارد شده نمیتواند کمتر از 1000 تومان باشد");
    }
}