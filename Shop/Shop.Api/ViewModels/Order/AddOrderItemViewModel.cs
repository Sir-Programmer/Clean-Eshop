namespace Shop.Api.ViewModels.Order;

public class AddOrderItemViewModel
{
    public Guid InventoryId { get; set; }
    public int Count { get; set; }
}