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
        var filter = request.FilterParams;
        var conditions = new List<string>();
        var parameters = new DynamicParameters();
        parameters.Add("status", SellerStatus.Accepted);

        CategoryDto? selectedCategory = null;

        if (!string.IsNullOrWhiteSpace(filter.CategorySlug))
        {
            var category = await context.Categories
                .FirstOrDefaultAsync(f => f.Slug == filter.CategorySlug, cancellationToken);

            if (category != null)
            {
                conditions.Add($@"
                                (A.MainCategoryId = @categoryId 
                                 OR EXISTS (
                                     SELECT 1 
                                     FROM {DapperContext.ProductSubCategories} psc 
                                     WHERE psc.ProductId = A.Id 
                                       AND psc.CategoryId = @categoryId
                                 ))");

                parameters.Add("categoryId", category.Id);
                selectedCategory = category.Map();
            }
        }


        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            conditions.Add("A.Title LIKE @search");
            parameters.Add("search", $"%{filter.Search}%");
        }

        if (filter.OnlyAvailableProducts)
            conditions.Add("A.Count >= 1");

        var inventoryOrderBy = "i.Price ASC";
        if (filter.JustHasDiscount)
        {
            conditions.Add("A.DiscountPercentage > 0");
            inventoryOrderBy = "i.DiscountPercentage DESC";
        }

        var orderBy = filter.SearchOrderBy switch
        {
            ProductSearchOrderBy.Cheapest => "A.Price ASC",
            ProductSearchOrderBy.Expensive => "A.Price DESC",
            ProductSearchOrderBy.Latest => "A.Id DESC",
            _ => "p.Id"
        };

        var whereClause = conditions.Count > 0 ? " AND " + string.Join(" AND ", conditions) : "";

        using var sqlConnection = dapperContext.CreateConnection();
        var skip = (filter.PageId - 1) * filter.Take;
        parameters.Add("skip", skip);
        parameters.Add("take", filter.Take);

        var baseQuery = $@"
            Select p.Title, i.Price, i.Id as InventoryId, i.DiscountPercentage, 
                   i.Count, p.MainCategoryId, p.Id as Id, p.Slug, p.ImageName, s.Status,
                   ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy}) AS RN
            From {DapperContext.Products} p
                 Left Join {DapperContext.Inventories} i On p.Id = i.ProductId
                 Left Join {DapperContext.Sellers} s On i.SellerId = s.Id
        ";

        var countSql = $@"
            SELECT Count(A.Title)
            FROM ({baseQuery}) A
            WHERE A.RN = 1 AND A.Status = @status {whereClause};
        ";

        var dataSql = $@"
            SELECT A.Slug, A.Id, A.Title, A.Price, A.InventoryId, 
                   A.DiscountPercentage, A.ImageName
            FROM ({baseQuery}) A
            WHERE A.RN = 1 AND A.Status = @status {whereClause}
            ORDER BY {orderBy}
            OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY;
        ";

        var count = await sqlConnection.QueryFirstAsync<int>(countSql, parameters);
        var result = await sqlConnection.QueryAsync<ProductShopDto>(dataSql, parameters);

        var model = new ProductShopResult
        {
            FilterParams = filter,
            Data = result.ToList(),
            CategoryDto = selectedCategory
        };

        model.GeneratePaging(count, filter.Take, filter.PageId);
        return model;
    }
}