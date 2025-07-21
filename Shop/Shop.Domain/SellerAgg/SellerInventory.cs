using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg;

public class SellerInventory : BaseEntity
{
    public SellerInventory(Guid productId, int count, int price, bool isActive, int? discountPercentage = null)
    {
        Guard(count, price);
        DiscountGuard(discountPercentage);
        ProductId = productId;
        Count = count;
        Price = price;
        IsActive = true;
        DiscountPercentage = discountPercentage;
    }
    public Guid ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public Guid SellerId { get; internal set; }
    public int? DiscountPercentage { get; private set; }
    public bool IsActive { get; private set; }

    public void Activate()
    {
        IsActive = true;
    }

    public void DeActivate()
    {
        IsActive = false;
    }

    public void ApplyDiscountPercentage(int discountPercentage)
    {
        DiscountGuard(discountPercentage);
        DiscountPercentage = discountPercentage;
    }

    public void Edit(int count, int price, bool isActive, int? discountPercentage)
    {
        Guard(count, price);
        DiscountGuard(discountPercentage);
        Count = count;
        Price = price;
        IsActive = isActive;
        DiscountPercentage = discountPercentage;
    }
    
    private void DiscountGuard(int? discountPercentage)
    {
        if (discountPercentage is > 70) throw new InvalidDomainDataException("تخفیف نمیتواند بیشتر از 70 درصد باشد");
    }
    
    private void Guard(int count, int price)
    {
        if (count < 0) throw new InvalidDomainDataException("تعداد نمیتواند کمتر از 10 باشد");
        if (price < 10000) throw new InvalidDomainDataException("مبلغ نمیتواند کمتر از 10,000 تومان باشد");
    }
}