using Common.Query;
using Shop.Domain.ProductAgg;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQuery(ProductFilterParams filterParams) : QueryFilter<ProductFilterResult, ProductFilterParams>(filterParams);