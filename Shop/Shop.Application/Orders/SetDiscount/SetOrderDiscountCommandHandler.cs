using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.SetDiscount;

public class SetOrderDiscountCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<SetOrderDiscountCommand>
{
    public async Task<OperationResult> Handle(SetOrderDiscountCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdTrackingAsync(request.OrderId);
        if (order == null) return OperationResult.NotFound();
        order.SetDiscount(request.DiscountType, request.DiscountAmount);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}