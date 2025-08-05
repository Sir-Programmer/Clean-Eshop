using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit;

public class EditProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IFileService fileService,
    IProductDomainService productDomainService) : IBaseCommandHandler<EditProductCommand>
{
    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdTrackingAsync(request.ProductId);
        if (product == null) return OperationResult.NotFound();
        var oldImage = product.ImageName;
        product.Edit(request.Title, request.Slug, request.Description, request.CategoryId, request.SeoData, productDomainService);

        var productSpecifications = request.Specifications
            .Select(spec => new ProductSpecification(spec.Key, spec.Value))
            .ToList();

        product.SetSpecifications(productSpecifications);
        product.SetSubCategories(request.SubCategoriesIds);

        if (request.ImageFile != null)
        {
            fileService.DeleteFile(Directories.ProductImages, oldImage);
            var newImageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            product.SetImageName(newImageName);
        }

        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}