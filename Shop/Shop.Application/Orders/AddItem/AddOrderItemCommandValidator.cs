using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidator()
    {
        RuleFor(o => o.Count)
            .GreaterThan(0).WithMessage("تعداد باید بیشتر از صفر باشد");
    }
}