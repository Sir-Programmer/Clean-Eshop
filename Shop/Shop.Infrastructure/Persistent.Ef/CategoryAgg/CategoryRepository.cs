using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg;

public class CategoryRepository(ShopContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public Task<bool> DeleteCategory(Guid categoryId)
    {
        throw new NotImplementedException();
    }
}