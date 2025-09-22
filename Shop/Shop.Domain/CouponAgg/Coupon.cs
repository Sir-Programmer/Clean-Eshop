using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Domain.CouponAgg;

public class Coupon : AggregateRoot
{
    public string Code { get; private set; }
    public DiscountType DiscountType { get; private set; }
    public int DiscountAmount { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public int UsageLimit { get; private set; }
    public int UsedCount { get; private set; }

    public Coupon(string code, DiscountType discountType, int discountAmount, DateTime expirationDate, int usageLimit)
    {
        Code = code;
        DiscountType = discountType;
        DiscountAmount = discountAmount;
        ExpirationDate = expirationDate;
        UsageLimit = usageLimit;
    }

    public bool IsValid() =>
        DateTime.UtcNow <= ExpirationDate && UsedCount < UsageLimit;

    public void MarkAsUsed()
    {
        if (!IsValid())
            throw new InvalidDomainDataException("کد تخفیف معتبر نمیباشد");

        UsedCount++;
    }

    private void Guard(string code, DiscountType discountType, int discountAmount, DateTime expirationDate, int usageLimit)
    {

    }
}