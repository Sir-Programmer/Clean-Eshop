using Common.Query;
using Shop.Domain._SharedKernel.Enums;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs;

public class OrderDto : BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public OrderAddress? Address { get; set; }
    public OrderDiscount? Discount { get; set; }
    public OrderShippingMethod? ShippingMethod { get; set; }
    public DateTime? LastUpdate { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(i => i.TotalPrice);
            if (ShippingMethod != null)
            {
                var shippingCost = ShippingMethod.ShippingCost;
                totalPrice += shippingCost;
            }
            if (Discount != null)
            {
                switch (Discount.DiscountType)
                {
                    case DiscountType.Fixed:
                        totalPrice -= Discount.DiscountAmount;
                        break;

                    case DiscountType.Percentage:
                        var percentageAmount = totalPrice * Discount.DiscountAmount / 100;
                        totalPrice -= percentageAmount;
                        break;
                    default:
                        throw new Exception();
                }
            }
            return totalPrice;
        }
    }
}