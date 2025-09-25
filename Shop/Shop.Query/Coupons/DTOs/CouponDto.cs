using Common.Query;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Query.Coupons.DTOs;

public class CouponDto : BaseDto
{
    public string Code { get; set; }
    public DiscountType DiscountType { get; set; }
    public int DiscountAmount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int UsageLimit { get; set; }
    public int UsedCount { get; set; }
}