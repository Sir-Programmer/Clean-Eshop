namespace Shop.Domain.SellerAgg.Services;

public interface ISellerDomainService
{
    bool IsNationalIdExist(string nationalId);
}