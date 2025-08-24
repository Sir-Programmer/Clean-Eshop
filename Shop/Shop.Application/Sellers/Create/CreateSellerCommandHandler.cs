using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Sellers.Create;

public class CreateSellerCommandHandler(ISellerRepository sellerRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, ISellerDomainService sellerDomainService) : IBaseCommandHandler<CreateSellerCommand, Guid>
{
    public async Task<OperationResult<Guid>> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user == null) return OperationResult<Guid>.NotFound();
        var seller = new Seller(request.UserId, request.ShopName, request.NationalId, sellerDomainService);
        await sellerRepository.AddAsync(seller);
        await unitOfWork.SaveChangesAsync();
        return OperationResult<Guid>.Success(seller.Id);
    }
}