using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.SiteEntities.ShippingMethod.Repository;

namespace Shop.Application.SiteEntities.ShippingMethods.Delete;

public class DeleteShippingMethodCommandHandler(IShippingMethodRepository shippingMethodRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<DeleteShippingMethodCommand>
{
    public async Task<OperationResult> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shippingMethod = await shippingMethodRepository.GetByIdAsync(request.ShippingMethodId);
        if (shippingMethod == null) return OperationResult.NotFound();
        shippingMethodRepository.Delete(shippingMethod);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}