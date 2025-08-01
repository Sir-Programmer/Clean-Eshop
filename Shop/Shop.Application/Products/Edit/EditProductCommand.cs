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
    SeoData SeoData,
    List<Guid> CategoryIds,
    Dictionary<string, string> Specifications): IBaseCommand;