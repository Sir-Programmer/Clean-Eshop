using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage;

public class AddProductImageCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IFileService fileService) : IBaseCommandHandler<AddProductImageCommand>
{
    public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdTrackingAsync(request.ProductId);
        if (product == null) return OperationResult.NotFound();
        var imageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImagesGallery);
        product.AddImage(imageName, request.Sequence);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}