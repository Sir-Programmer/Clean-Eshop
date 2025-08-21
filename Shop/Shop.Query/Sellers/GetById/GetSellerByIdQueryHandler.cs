using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById;

public class GetSellerByIdQueryHandler(ShopContext context) : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await context.Sellers.FirstOrDefaultAsync(s => s.Id == request.SellerId, cancellationToken);
        return seller.Map();
    }
}