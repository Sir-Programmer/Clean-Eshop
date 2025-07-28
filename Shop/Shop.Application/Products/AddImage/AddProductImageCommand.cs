using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage;

public record AddProductImageCommand(
    Guid ProductId,
    IFormFile ImageFile,
    int Sequence) : IBaseCommand;