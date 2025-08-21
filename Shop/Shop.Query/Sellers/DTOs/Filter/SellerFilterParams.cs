using Common.Query.Filter;

namespace Shop.Query.Sellers.DTOs.Filter;

public class SellerFilterParams : BaseFilterParam
{
    public string ShopName { get; set; }
    public string NationalId { get; set; }
}