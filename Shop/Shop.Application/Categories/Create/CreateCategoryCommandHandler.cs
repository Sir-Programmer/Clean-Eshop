using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService, IUnitOfWork unitOfWork) : IBaseCommandHandler<CreateCategoryCommand>
{
    public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Title, request.Slug, request.SeoData, categoryDomainService);
        await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}