using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.SiteEntities.ShippingMethod.Repository;

namespace Shop.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommandHandler(IShippingMethodRepository shippingMethodRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditShippingMethodCommand>
{
    public async Task<OperationResult> Handle(EditShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shippingMethod = await shippingMethodRepository.GetByIdTrackingAsync(request.ShippingMethodId);
        if (shippingMethod == null) return OperationResult.NotFound();
        shippingMethod.Eidt(request.Title, request.Cost);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}