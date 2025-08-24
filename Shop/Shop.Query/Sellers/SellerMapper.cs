using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers;

public static class SellerMapper
{
    public static SellerDto? MapOrNull(this Seller? seller)
    {
        return seller?.Map();
    }
    
    public static SellerDto Map(this Seller seller)
    {
        return new SellerDto
        {
            Id = seller.Id,
            CreationTime = seller.CreationTime,
            NationalId = seller.NationalId,
            ShopName = seller.ShopName,
            Status = seller.Status,
            UserId = seller.UserId
        };
    }
}