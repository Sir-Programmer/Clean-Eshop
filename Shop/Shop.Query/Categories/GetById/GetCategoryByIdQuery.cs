using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById;

public record GetCategoryByIdQuery (Guid CategoryId) : IQuery<CategoryDto?>;