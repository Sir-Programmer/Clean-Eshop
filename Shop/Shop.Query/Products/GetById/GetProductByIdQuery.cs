using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById;

public record GetProductByIdQuery(Guid ProductId) : IQuery<ProductDto?>;