using Common.Domain;

namespace Shop.Domain.ProductAgg;

public class ProductCategoryItem : BaseEntity
{
    private ProductCategoryItem()
    {
        
    }
    public ProductCategoryItem(Guid categoryId)
    {
        CategoryId = categoryId;
    }
    public Guid ProductId { get; internal set; }
    public Guid CategoryId { get; private set; }
}