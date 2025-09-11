using Common.Query;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg.Enums;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories;
using Shop.Query.Categories.DTOs;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Query.Products.GetForShop;

public class GetProductForShopQueryHandler(DapperContext dapperContext, ShopContext context) : IQueryHandler<GetProductForShopQuery, ProductShopResult>
{
    public async Task<ProductShopResult> Handle(GetProductForShopQuery request, CancellationToken cancellationToken)
    {
        var filters = request.FilterParams;
        var conditions = new List<string>();
        var inventoryOrderBy = "i.Price Asc";
        CategoryDto? selectedCategory = null;

        if (!string.IsNullOrWhiteSpace(filters.CategorySlug))
        {
            var category = await context.Categories
                .FirstOrDefaultAsync(f => f.Slug == filters.CategorySlug, cancellationToken);

            if (category != null)
            {
                const string mainCondition = "A.MainCategoryId = @catId";
                const string subCondition = $"EXISTS (SELECT 1 FROM {DapperContext.ProductSubCategories} ps WHERE ps.ProductId = A.Id AND ps.CategoryId = @catId)";

                conditions.Add($"({mainCondition} OR {subCondition})");
                selectedCategory = category.Map();
            }
        }


        if (!string.IsNullOrWhiteSpace(filters.Search))
            conditions.Add("A.Title LIKE @search");

        if (filters.OnlyAvailableProducts)
            conditions.Add("A.Count >= 1");

        if (filters.JustHasDiscount)
        {
            conditions.Add("A.DiscountPercentage > 0");
            inventoryOrderBy = "i.DiscountPercentage Desc";
        }

        var orderMapping = new Dictionary<ProductSearchOrderBy, string>
        {
            [ProductSearchOrderBy.Cheapest] = "A.Price Asc",
            [ProductSearchOrderBy.Expensive] = "A.Price Desc",
            [ProductSearchOrderBy.Latest] = "A.Id Desc"
        };
        var orderBy = orderMapping.GetValueOrDefault(filters.SearchOrderBy, "p.Id");

        var whereClause = conditions.Count > 0 ? " and " + string.Join(" and ", conditions) : string.Empty;
        var skip = (filters.PageId - 1) * filters.Take;

        using var sqlConnection = dapperContext.CreateConnection();

        var countSql = $"""
                        SELECT Count(A.Title)
                        FROM (
                            Select p.Title, i.Price, i.Id as InventoryId, i.DiscountPercentage, i.Count,
                                   p.CategoryId, p.SubCategoryId, p.SecondarySubCategoryId, p.Id as Id, s.Status,
                                   ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy}) AS RN
                            From {DapperContext.Products} p
                            left join {DapperContext.Inventories} i on p.Id=i.ProductId
                            left join {DapperContext.Sellers} s on i.SellerId=s.Id
                        )A
                        WHERE A.RN = 1 and A.Status=@status {whereClause}
                        """;

        var resultSql = $"""
                         SELECT A.Slug, A.Id, A.Title, A.Price, A.InventoryId, A.DiscountPercentage, A.ImageName
                         FROM (
                             Select p.Title, i.Price, i.Id as InventoryId, i.DiscountPercentage, p.ImageName, i.Count,
                                    p.CategoryId, p.SubCategoryId, p.SecondarySubCategoryId, p.Slug, p.Id as Id, s.Status,
                                    ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy}) AS RN
                             From {DapperContext.Products} p
                             left join {DapperContext.Inventories} i on p.Id=i.ProductId
                             left join {DapperContext.Sellers} s on i.SellerId=s.Id
                         )A
                         WHERE A.RN = 1 and A.Status=@status {whereClause}
                         order by {orderBy}
                         offset @skip rows fetch next @take rows only
                         """;

        var count = await sqlConnection.QuerySingleAsync<int>(countSql, new
        {
            status = SellerStatus.Accepted,
            catId = selectedCategory?.Id,
            search = $"%{filters.Search}%"
        });

        var result = await sqlConnection.QueryAsync<ProductShopDto>(resultSql, new
        {
            skip,
            take = filters.Take,
            status = SellerStatus.Accepted,
            catId = selectedCategory?.Id,
            search = $"%{filters.Search}%"
        });

        var model = new ProductShopResult
        {
            FilterParams = filters,
            Data = result.ToList(),
            CategoryDto = selectedCategory
        };
        model.GeneratePaging(count, filters.Take, filters.PageId);

        return model;
    }
}
