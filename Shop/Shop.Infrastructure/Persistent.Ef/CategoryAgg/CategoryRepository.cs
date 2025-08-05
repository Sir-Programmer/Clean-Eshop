using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg;

public class CategoryRepository(ShopContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public async Task<bool> DeleteCategory(Guid categoryId)
    {
        var category = await context.Categories
            .Include(c => c.Childs)
            .ThenInclude(c => c.Childs)
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category == null) return false;

        var existProduct = await Context.Products
            .Include(p => p.SubCategories)
            .AnyAsync(p =>
                p.MainCategoryId == categoryId || p.SubCategories.Any(s => s.CategoryId == categoryId));

        if (existProduct) return false;

        if (category.Childs.Any(c => c.Childs.Count != 0))
        {
            Context.RemoveRange(category.Childs.SelectMany(s => s.Childs));
        }

        Context.RemoveRange(category.Childs);
        Context.RemoveRange(category);
        return true;
    }
}