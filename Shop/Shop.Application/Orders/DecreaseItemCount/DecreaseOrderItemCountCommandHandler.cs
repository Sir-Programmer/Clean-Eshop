using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<DecreaseOrderItemCountCommand>
{
    public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null) return OperationResult.NotFound();
        order.DecreaseItemCount(request.ItemId, request.Count);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}