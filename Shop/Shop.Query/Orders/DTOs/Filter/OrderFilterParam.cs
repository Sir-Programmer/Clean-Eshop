using Common.Query.Filter;
using Shop.Domain.OrderAgg.Enums;

namespace Shop.Query.Orders.DTOs.Filter;

public class OrderFilterParam : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }
}