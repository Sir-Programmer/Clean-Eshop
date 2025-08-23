using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products;

public class ProductDomainService(IProductRepository productRepository) : IProductDomainService
{
    public bool IsSlugExist(string slug)
    {
        return productRepository.Exists(p => p.Slug == slug);
    }
}