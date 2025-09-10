using Common.Query;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Query.Products.GetForShop;

public class GetProductForShopQuery(ProductShopFilterParams filterParams) : QueryFilter<ProductShopResult, ProductShopFilterParams>(filterParams);