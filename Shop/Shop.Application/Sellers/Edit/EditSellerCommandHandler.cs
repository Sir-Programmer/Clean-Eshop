using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit;

public class EditSellerCommandHandler(ISellerRepository sellerRepository, IUnitOfWork unitOfWork, ISellerDomainService sellerDomainService) : IBaseCommandHandler<EditSellerCommand>
{
    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await sellerRepository.GetByIdTrackingAsync(request.SellerId);
        if  (seller == null) return OperationResult.NotFound();
        seller.Edit(request.ShopName, request.NationalId, sellerDomainService);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}