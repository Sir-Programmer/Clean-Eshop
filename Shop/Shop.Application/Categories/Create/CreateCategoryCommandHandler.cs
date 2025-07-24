using Common.Application;
using Common.Application.OperationResults;

namespace Shop.Application.Categories.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, OperationResult>
{
    public Task<OperationResult<OperationResult>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}