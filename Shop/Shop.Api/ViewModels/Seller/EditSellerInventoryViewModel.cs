namespace Shop.Api.ViewModels.Seller;

public class EditSellerInventoryViewModel
{
    public int Count { get; set; }
    public int Price { get; set; }
    public int? DiscountPercentage { get; set; }
    public bool IsActive { get; set; }
}