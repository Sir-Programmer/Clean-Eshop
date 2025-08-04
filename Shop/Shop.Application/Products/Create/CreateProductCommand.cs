using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.Create;

public record CreateProductCommand(
    string Title,
    string Slug,
    string Description,
    IFormFile ImageFile,
    SeoData SeoData,
    Guid CategoryId,
    Guid SubCategoryId,
    Guid SecondSubCategoryId,
    Dictionary<string, string> Specifications)
    : IBaseCommand;