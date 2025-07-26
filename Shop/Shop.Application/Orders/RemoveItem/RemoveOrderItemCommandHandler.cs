using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem;

public class RemoveOrderItemCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<RemoveOrderItemCommand>
{
    public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null) return OperationResult.NotFound();
        order.RemoveItem(request.ItemId);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}