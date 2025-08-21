using Common.Query;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Query.Sellers.GetByFilter;

public class GetSellerByFilterQuery(SellerFilterParams filterParams) : QueryFilter<SellerFilterResult, SellerFilterParams>(filterParams);