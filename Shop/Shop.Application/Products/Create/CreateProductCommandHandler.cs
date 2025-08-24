using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create;

internal class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IFileService fileService,
    IProductDomainService productDomainService) : IBaseCommandHandler<CreateProductCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = await fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

        var product = new Product(request.Title, request.Slug, request.Description, imageName, request.CategoryId, request.SeoData, productDomainService);

        await productRepository.AddAsync(product);

        var productSpecifications = request.Specifications
            .Select(spec => new ProductSpecification(spec.Key, spec.Value))
            .ToList();

        product.SetSpecifications(productSpecifications);
        product.SetSubCategories(request.SubCategoriesIds);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(product.Id);
    }
}