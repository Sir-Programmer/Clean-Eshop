using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories.Remove;

public class RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<RemoveCategoryCommand>
{
    public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await categoryRepository.DeleteCategory(request.CategoryId);
        if (!result) return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();

    }
}