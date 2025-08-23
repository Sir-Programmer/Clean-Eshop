using Common.Query;
using Common.Query.Filter;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Query.Sellers.Inventories.GetByFilter;

public class GetSellerInventoryByFilterQueryHandler(DapperContext dapperContext) : IQueryHandler<GetSellerInventoryByFilterQuery, SellerInventoryFilterResult>
{
    public async Task<SellerInventoryFilterResult> Handle(GetSellerInventoryByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        using var connection = dapperContext.CreateConnection();
        const string sql = $"""
                            SELECT 
                                p.Id AS ProductId, 
                                p.Title AS ProductTitle, 
                                p.ImageName AS ProductImage, 
                                i.Count, 
                                i.Price, 
                                s.Id AS SellerId, 
                                s.ShopName, 
                                i.DiscountPercentage, 
                                i.IsActive 
                            FROM {DapperContext.Inventories} i INNER JOIN {DapperContext.Sellers} s ON s.Id = i.SellerId
                            INNER JOIN {DapperContext.Products} p ON p.Id = i.ProductId
                            WHERE i.SellerId = @SellerId
                            ORDER BY i.Id
                            OFFSET (@Skip) ROWS FETCH NEXT (@Take) ROWS ONLY;

                            SELECT COUNT(*) 
                            FROM {DapperContext.Inventories} WHERE SellerId = @SellerId
                            """;

        await using var multi = await connection.QueryMultipleAsync(sql, new
        {
            @params.SellerId,
            Skip = (@params.PageId - 1) * @params.Take,
            Take = @params.Take
        });

        var inventories = await multi.ReadAsync<InventoryDto?>();
        var totalCount = await multi.ReadFirstAsync<int>();
        
        var result = new SellerInventoryFilterResult
        {
            Data = inventories.ToList(),
            FilterParams = @params
        };
        
        result.GeneratePaging(totalCount, @params.Take, @params.PageId);
        return result;

    }
}