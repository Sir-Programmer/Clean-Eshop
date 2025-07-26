using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidator()
    {
        RuleFor(command => command.Count)
            .GreaterThan(0).WithMessage("تعداد باید بیشتر از صفر باشد");
    }
}