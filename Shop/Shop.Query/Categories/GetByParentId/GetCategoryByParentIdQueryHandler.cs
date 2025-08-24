using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId;

public class GetCategoryByParentIdQueryHandler(ShopContext context) : IQueryHandler<GetCategoryByParentIdQuery, List<CategoryDto?>>
{
    public async Task<List<CategoryDto?>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories
            .Where(c => c.ParentId == request.ParentId)
            .Include(c => c.Childs)
            .ThenInclude(c => c.Childs)
            .OrderByDescending(c => c.CreationTime)
            .ToListAsync(cancellationToken);
        return categories.Map();
    }
}