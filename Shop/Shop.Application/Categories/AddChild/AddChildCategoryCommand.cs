using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.AddChild;

public record AddChildCategoryCommand(Guid ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand<Guid>;
