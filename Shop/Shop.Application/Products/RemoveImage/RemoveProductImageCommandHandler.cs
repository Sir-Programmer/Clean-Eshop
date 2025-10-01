using Common.Application;
using Common.Application.FileUtil;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage;

public class RemoveProductImageCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<RemoveProductImageCommand>
{
    public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdTrackingAsync(request.ProductId);
        if (product == null) return OperationResult.NotFound(); 
        fileService.DeleteFile(Directories.ProductImagesGallery, product.ImageName);
        product.RemoveImage(request.ImageId);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}