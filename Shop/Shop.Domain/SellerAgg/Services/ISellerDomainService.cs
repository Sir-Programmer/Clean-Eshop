namespace Shop.Domain.SellerAgg.Services;

public interface ISellerDomainService
{
    bool IsNationalIdExistInDb(string nationalId);
}