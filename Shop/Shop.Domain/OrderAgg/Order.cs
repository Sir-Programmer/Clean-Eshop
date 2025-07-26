using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SharedKernel.Enums;

namespace Shop.Domain.OrderAgg;

public class Order : AggregateRoot
{
    public Order(Guid userId)
    {
        UserId = userId;
        Status = OrderStatus.Created;
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
                        throw new InvalidDomainDataException("Invalid Discount Type ");
                }
            }
            return totalPrice;
        }
    }

    public void AddItem(Guid inventoryId, int count, int price)
    {
        ChangeOrderGuard();
        
        var orderItem = Items.FirstOrDefault(x => x.Id == Id);
        if (orderItem != null) 
            orderItem.IncrementCount(1);
        else 
            Items.Add(new OrderItem(inventoryId, count, price));
    }

    public void RemoveItem(Guid itemId)
    {
        ChangeOrderGuard();
        
        var orderItem = Items.FirstOrDefault(x => x.Id == itemId);
        if (orderItem != null)
            Items.Remove(orderItem);
    }
    
    public void IncreaseItemCount(Guid itemId, int count)
    {
        ChangeOrderGuard();

        var orderItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (orderItem == null)
            throw new NullOrEmptyDomainException();

        orderItem.IncrementCount(count);
    }

    public void DecreaseItemCount(Guid itemId, int count)
    {
        ChangeOrderGuard();

        var orderItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (orderItem == null)
            throw new NullOrEmptyDomainException();

        orderItem.DecrementCount(count);
    }

    public void Checkout(OrderAddress address, OrderShippingMethod shippingMethod)
    {
        ChangeOrderGuard();
        
        Address = address;
        ShippingMethod = shippingMethod;
        Status = OrderStatus.WaitingForPayment;
        LastUpdate = DateTime.Now;
    }

    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    public void Finally()
    {
        Status = OrderStatus.SuccessPayment;
        LastUpdate = DateTime.Now;
    }

    private void ChangeOrderGuard()
    {
        if (Status != OrderStatus.Created)
            throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد");
    }
}