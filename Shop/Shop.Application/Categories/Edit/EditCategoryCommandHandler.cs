using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Edit;

public class EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditCategoryCommand>
{
    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdTrackingAsync(request.Id);
        if (category == null) return OperationResult.NotFound();
        category.Edit(request.Title, request.Slug, request.SeoData, categoryDomainService);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}