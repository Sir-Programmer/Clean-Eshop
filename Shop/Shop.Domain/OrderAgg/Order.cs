using Common.Domain;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg;

public class Order : AggregateRoot
{
    public Order(Guid userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        Items = [];
    }
    public Guid UserId { get; private set; }
    public OrderStatus Status { get; private set; }
    public OrderAddress? Address { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public OrderShippingMethod? ShippingMethod { get; private set; }
    public DateTime? LastUpdate { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public int TotalItems => Items.Count;
    public int TotalPriceWithoutDiscount => Items.Sum(i => i.TotalPrice);
}