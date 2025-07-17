using Fluxera.ValueObject;
using Shop.Domain.SharedKernel.Enums;

namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderDiscount(DiscountType discountType, int discountAmount) : ValueObject<OrderDiscount>
{
    public DiscountType DiscountType { get; private set; } = discountType;
    public int DiscountAmount { get; private set; } = discountAmount;
}