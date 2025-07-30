using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory;

public class AddSellerInventoryCommandHandler(ISellerRepository sellerRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<AddSellerInventoryCommand>
{
    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await sellerRepository.GetByIdTrackingAsync(request.SellerId);
        if (seller == null) return OperationResult.NotFound();

        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product == null) return OperationResult.NotFound();
        
        seller.AddInventory(request.ProductId, request.Count, request.Price, request.DiscountPercentage);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}