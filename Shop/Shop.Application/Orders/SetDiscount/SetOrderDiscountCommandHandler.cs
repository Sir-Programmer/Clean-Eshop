using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CouponAgg.Repository;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.SetDiscount;

public class SetOrderDiscountCommandHandler(IOrderRepository orderRepository, ICouponRepository couponRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<SetOrderDiscountCommand>
{
    public async Task<OperationResult> Handle(SetOrderDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = await couponRepository.GetByCodeTrackingAsync(request.CouponCode);
        var order = await orderRepository.GetByIdTrackingAsync(request.OrderId);
        if (order == null || coupon == null) return OperationResult.NotFound();
        if (!coupon.IsValid()) return OperationResult.Error("کد تخفیف نا معتبر میباشد");
        order.SetDiscount(coupon.DiscountType, coupon.DiscountAmount);
        coupon.MarkAsUsed();
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}