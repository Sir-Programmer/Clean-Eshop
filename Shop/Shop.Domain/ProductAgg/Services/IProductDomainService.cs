namespace Shop.Domain.ProductAgg.Services;

public interface IProductDomainService
{
    bool IsSlugExistInDb(string slug);
}