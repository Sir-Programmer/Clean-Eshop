using Shop.Domain._SharedKernel.Enums;

namespace Shop.Api.ViewModels.Coupon;

public class EditCouponViewModel
{
    public string Code { get; set; }
    public DiscountType DiscountType { get; set; }
    public int DiscountAmount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int UsageLimit { get; set; }
}