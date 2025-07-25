﻿using Common.Domain.Repository;

namespace Shop.Domain.CategoryAgg.Repository;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> DeleteCategory(Guid categoryId);
}