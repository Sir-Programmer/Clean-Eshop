using Common.Domain;

namespace Shop.Domain.OrderAgg;

public class OrderItem : BaseEntity
{
 public OrderItem(Guid orderId, Guid productId, int count, int price)
 {
  OrderId = orderId;
  ProductId = productId;
  Count = count;
  Price = price;
 }
 public Guid OrderId { get; private set; }
 public Guid ProductId { get; private set; }
 public int Count { get; private set; }
 public int Price { get; private set; }
 public int TotalPrice  => Price * Count;
}