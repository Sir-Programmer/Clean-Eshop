using Common.Application;
using Common.Application.OperationResults;

namespace Shop.Application.Products.Create;

internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    public Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}