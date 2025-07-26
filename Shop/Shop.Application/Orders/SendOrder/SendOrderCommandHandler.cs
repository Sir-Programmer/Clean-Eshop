using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.SendOrder;

public class SendOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<SendOrderCommand>
{
    public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.OrderId);
        if (order == null) return OperationResult.NotFound();
        order.ChangeStatus(OrderStatus.Shipping);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}