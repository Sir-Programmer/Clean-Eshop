using Common.Application;

namespace Shop.Application.Products.RemoveImage;

public record RemoveProductImageCommand(
    Guid ProductId,
    Guid ImageId
    ) : IBaseCommand;