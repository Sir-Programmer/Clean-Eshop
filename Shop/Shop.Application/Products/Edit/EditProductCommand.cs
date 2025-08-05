using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Edit;

public record EditProductCommand(
    Guid ProductId,
    string Title,
    string Slug,
    string Description,
    IFormFile? ImageFile,
    Guid CategoryId,
    SeoData SeoData,
    List<Guid> SubCategoriesIds,
    Dictionary<string, string> Specifications): IBaseCommand;