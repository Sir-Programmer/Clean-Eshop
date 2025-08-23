using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers;

public class SellerDomainService(ISellerRepository sellerRepository) : ISellerDomainService
{
    public bool IsNationalIdExist(string nationalId)
    {
        return sellerRepository.Exists(s => s.NationalId == nationalId);
    }

    public bool IsUserIdExist(Guid userId)
    {
        return sellerRepository.Exists(s => s.UserId == userId);
    }
}