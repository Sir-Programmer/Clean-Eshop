using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<AddOrderItemCommand>
{
    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null) return OperationResult.NotFound();
        
        if (request.Count > inventory.Count)
            return OperationResult.Error("تعداد محصول درخواستی بیشتر از موجودی انبار میباشد");

        var order = await orderRepository.GetCurrentUserOrder(request.UserId) ?? new Order(request.UserId);
        
        order.AddItem(inventory.Id, request.Count, inventory.Price);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}