namespace Shop.Query.Sellers.DTOs;

public class InventoryDto
{
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }
    public string ProductImage { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public Guid SellerId { get; set; }
    public int? DiscountPercentage { get;  set; }
    public bool IsActive { get; set; }
}