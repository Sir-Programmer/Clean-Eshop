using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Products.DTOs;

public class ProductDetailsDto
{
    public List<InventoryDto> Inventories { get; set; }
    public ProductDto Details { get; set; }
}