using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<IncreaseOrderItemCountCommand>
{
    public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetCurrentUserOrder(request.UserId);
        if (order == null) return OperationResult.NotFound();
        var inventoryId = order.Items.FirstOrDefault(i => i.Id == request.ItemId)?.InventoryId;
        if (inventoryId == null) return OperationResult.NotFound();
        var inventory = await sellerRepository.GetInventoryById((Guid)inventoryId);
        if (inventory == null) return OperationResult.NotFound();
        if (inventory.Count < request.Count) return OperationResult.Error("تعداد محصول درخواستی بیشتر از موجودی انبار میباشد");
        order.IncreaseItemCount(request.ItemId, request.Count);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}