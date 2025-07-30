using FluentValidation;

namespace Shop.Application.Sellers.AddInventory;

public class AddSellerInventoryCommandValidator : AbstractValidator<AddSellerInventoryCommand>
{
    public AddSellerInventoryCommandValidator()
    {
        RuleFor(command => command.Count)
            .GreaterThan(0)
            .WithMessage("تعداد مجودی نمیتواند کمتر از 1 باشد");

        RuleFor(command => command.Price)
            .GreaterThanOrEqualTo(1000)
            .WithMessage("مبلغ وارد شده نمیتواند کمتر از 1000 تومان باشد");
    }
}