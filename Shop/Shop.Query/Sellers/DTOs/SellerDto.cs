using Common.Query;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Query.Sellers.DTOs;

public class SellerDto : BaseDto
{
    public Guid UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalId { get; set; }
    public SellerStatus Status { get; set; }
}