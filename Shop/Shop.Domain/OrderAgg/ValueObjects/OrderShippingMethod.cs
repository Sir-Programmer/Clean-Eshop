namespace Shop.Domain.OrderAgg.ValueObjects;

public class OrderShippingMethod(string shippingType, int shippingCost)
{
    public string ShippingType { get; private set; } = shippingType;
    public int ShippingCost { get; private set; } = shippingCost;
}