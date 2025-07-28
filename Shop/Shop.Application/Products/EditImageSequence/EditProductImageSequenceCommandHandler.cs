using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.EditImageSequence;

public class EditProductImageSequenceCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditProductImageSequenceCommand>
{
    public async Task<OperationResult> Handle(EditProductImageSequenceCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product == null) return OperationResult.NotFound();
        product.SetImageSequence(request.ImageId, request.Sequence);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}