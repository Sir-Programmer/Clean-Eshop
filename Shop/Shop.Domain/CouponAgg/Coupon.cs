using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Domain.CouponAgg;

public class Coupon : AggregateRoot
{
    private Coupon() {}
    public Coupon(string code, DiscountType discountType, int discountAmount, DateTime expirationDate, int usageLimit, ICouponDomainService couponDomainService)
    {
        Guard(code, discountType, discountAmount, expirationDate, usageLimit, couponDomainService);
        Code = code;
        DiscountType = discountType;
        DiscountAmount = discountAmount;
        ExpirationDate = expirationDate;
        UsageLimit = usageLimit;
    }
    public string Code { get; private set; }
    public DiscountType DiscountType { get; private set; }
    public int DiscountAmount { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public int UsageLimit { get; private set; }
    public int UsedCount { get; private set; }


    public void Edit(string code, DiscountType discountType, int discountAmount, DateTime expirationDate, int usageLimit, ICouponDomainService couponDomainService)
    {
        Guard(code, discountType, discountAmount, expirationDate, usageLimit, couponDomainService);
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

    private void Guard(string code, DiscountType discountType, int discountAmount, DateTime expirationDate, int usageLimit, ICouponDomainService couponDomainService)
    {
        if (code != Code)
        {
            NullOrEmptyDomainException.CheckString(code, nameof(code));
            if (code.Length < 6)
                throw new InvalidDomainDataException("کد تخفیف نمی‌تواند کمتر از ۶ کاراکتر باشد");

            if (couponDomainService.IsCodeExist(code))
                throw new InvalidDomainDataException("کد تخفیف وارد شده تکراری میباشد");
        }


        if (discountType is DiscountType.Percentage && discountAmount is > 100 or < 1)
            throw new InvalidDomainDataException("درصد تخفیف نامعتبر است");

        if (discountType is DiscountType.Fixed && discountAmount < 1000)
            throw new InvalidDomainDataException("حداقل مبلغ تخفیف هزار تومان می‌باشد");

        if (expirationDate <= DateTime.Now)
            throw new InvalidDomainDataException("تاریخ انقضا معتبر نیست");

        if (usageLimit < 1)
            throw new InvalidDomainDataException("لیمیت وارد شده نامعتبر است");
    }
}