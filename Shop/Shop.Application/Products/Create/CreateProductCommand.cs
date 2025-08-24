using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Create;

public record CreateProductCommand(
    string Title,
    string Slug,
    string Description,
    IFormFile ImageFile,
    SeoData SeoData,
    Guid CategoryId,
    List<Guid> SubCategoriesIds,
    Dictionary<string, string> Specifications)
    : IBaseCommand<Guid>;