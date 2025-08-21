using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById;

public record GetSellerByIdQuery(Guid SellerId) : IQuery<SellerDto?>;