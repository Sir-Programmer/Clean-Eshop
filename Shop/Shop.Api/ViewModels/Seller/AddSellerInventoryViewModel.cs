namespace Shop.Api.ViewModels.Seller;

public class AddSellerInventoryViewModel
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int? DiscountPercentage { get; set; }
}