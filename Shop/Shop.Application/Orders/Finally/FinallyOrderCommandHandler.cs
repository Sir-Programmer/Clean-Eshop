using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.Finally;

public class FinallyOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<FinallyOrderCommand>
{
    public async Task<OperationResult> Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.OrderId);
        if (order == null) return OperationResult.NotFound();
        order.Finally();
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}