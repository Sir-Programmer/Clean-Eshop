using Common.Query;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Query.Sellers.Inventories.GetByFilter;

public class GetSellerInventoryByFilterQuery(SellerInventoryFilterParams filterParams) : QueryFilter<SellerInventoryFilterResult, SellerInventoryFilterParams>(filterParams);