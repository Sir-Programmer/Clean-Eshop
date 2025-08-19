using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId;

public class GetCategoryByParentIdQueryHandler(ShopContext context) : IQueryHandler<GetCategoryByParentIdQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.ParentId == request.ParentId, cancellationToken);
        return category.Map();
    }
}