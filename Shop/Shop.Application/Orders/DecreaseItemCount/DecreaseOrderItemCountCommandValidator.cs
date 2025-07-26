using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandValidator : AbstractValidator<DecreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidator()
    {
        RuleFor(command => command.Count)
            .GreaterThan(1).WithMessage("تعداد نمیتواند کمتر از یک باشد");
    }
}