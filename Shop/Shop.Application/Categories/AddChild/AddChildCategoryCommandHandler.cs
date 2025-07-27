using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild;

internal class AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService, IUnitOfWork unitOfWork) : IBaseCommandHandler<AddChildCategoryCommand>
{
    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var parentCategory = await categoryRepository.GetByIdTrackingAsync(request.ParentId);
        if (parentCategory == null) return OperationResult.NotFound("والد دسته بندی یافت نشد");
        parentCategory.AddChild(request.Title, request.Slug, request.SeoData, categoryDomainService);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}