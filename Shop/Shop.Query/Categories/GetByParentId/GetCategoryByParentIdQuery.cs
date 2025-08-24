using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId;

public record GetCategoryByParentIdQuery(Guid ParentId) : IQuery<List<CategoryDto>>;