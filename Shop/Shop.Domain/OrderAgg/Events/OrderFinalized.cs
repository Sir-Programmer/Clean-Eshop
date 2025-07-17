using Common.Domain;

namespace Shop.Domain.OrderAgg.Events;

public class OrderFinalized(Guid orderId) : BaseDomainEvent
{
    public Guid OrderId { get; private set; } = orderId;
}