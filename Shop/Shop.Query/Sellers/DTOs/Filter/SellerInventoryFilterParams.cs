using Common.Query.Filter;

namespace Shop.Query.Sellers.DTOs.Filter;

public class SellerInventoryFilterParams : BaseFilterParam
{
    public Guid SellerId { get; set; }
}