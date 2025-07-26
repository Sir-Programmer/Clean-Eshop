using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SiteEntities.ShippingMethod.Repository;

namespace Shop.Application.Orders.Checkout;

public class CheckoutOrderCommandHandler(IOrderRepository orderRepository, IShippingMethodRepository shippingMethodRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<CheckoutOrderCommand>
{
    public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null) return OperationResult.NotFound();
        var shippingMethod = await shippingMethodRepository.GetByIdAsync(request.ShippingMethodId);
        if (shippingMethod == null) return OperationResult.NotFound("شیوه ارسال یافت نشد");
        order.Checkout(
            new OrderAddress(request.Province, request.City, request.PostalCode, request.FullName,
                request.PostalAddress, request.PhoneNumber, request.NationalId),
            new OrderShippingMethod(shippingMethod.Title, shippingMethod.Cost));
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}