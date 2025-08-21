using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByUserId;

public class GetSellerByUserIdQueryHandler(ShopContext context) :  IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
    public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await context.Sellers.FirstOrDefaultAsync(s => s.UserId == request.UserId, cancellationToken);
        return seller.Map();
    }
}