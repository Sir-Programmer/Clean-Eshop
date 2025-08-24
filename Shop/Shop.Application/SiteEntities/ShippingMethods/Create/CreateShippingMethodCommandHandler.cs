using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.SiteEntities.ShippingMethod;
using Shop.Domain.SiteEntities.ShippingMethod.Repository;

namespace Shop.Application.SiteEntities.ShippingMethods.Create;

public class CreateShippingMethodCommandHandler(IShippingMethodRepository shippingMethodRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<CreateShippingMethodCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shippingMethod = new ShippingMethod(request.Title, request.Cost);
        await shippingMethodRepository.AddAsync(shippingMethod);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(shippingMethod.Id);
    }
}