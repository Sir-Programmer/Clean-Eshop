using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
{
    public IncreaseOrderItemCountCommandValidator()
    {
        RuleFor(command => command.Count)
            .GreaterThan(1).WithMessage("تعداد نمیتواند کمتر از یک باشد");
    }
}