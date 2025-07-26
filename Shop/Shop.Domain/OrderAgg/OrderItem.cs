using Common.Domain;

namespace Shop.Domain.OrderAgg;

public class OrderItem : BaseEntity
{
    public OrderItem(Guid inventoryId, int count, int price)
    {
        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }

    public Guid OrderId { get; private set; }
    public Guid InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Price * Count;

    public void IncrementCount(int count)
    {
        Count += count;
    }

    public void DecrementCount(int count)
    {
        if (count > 0) return;
        Count -= count;
    }
}