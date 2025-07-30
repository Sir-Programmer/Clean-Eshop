using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInventory;

public class EditSellerInventoryCommandHandler(ISellerRepository sellerRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditSellerInventoryCommand>
{
    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await sellerRepository.GetByIdTrackingAsync(request.SellerId);
        if (seller == null) return OperationResult.NotFound();
        
        seller.EditInventory(request.InventoryId, request.Count, request.Price, request.IsActive, request.DiscountPercentage);
        await unitOfWork.SaveChangesAsync();
        
        return OperationResult.Success();
    }
}