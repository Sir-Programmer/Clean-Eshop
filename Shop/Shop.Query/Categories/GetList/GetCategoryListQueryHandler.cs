using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList;

public class GetCategoryListQueryHandler(ShopContext context) : IQueryHandler<GetCategoryListQuery, List<CategoryDto?>>
{
    public async Task<List<CategoryDto?>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories
            .Where(c => c.ParentId == null)
            .Include(c => c.Childs)
            .ThenInclude(c => c.Childs)
            .OrderByDescending(c => c.CreationTime)
            .ToListAsync(cancellationToken);
        return categories.Map();
    }
}