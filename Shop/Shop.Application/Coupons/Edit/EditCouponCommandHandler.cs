using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CouponAgg;
using Shop.Domain.CouponAgg.Repository;

namespace Shop.Application.Coupons.Edit;

public class EditCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork, ICouponDomainService couponDomainService) : IBaseCommandHandler<EditCouponCommand>
{
    public async Task<OperationResult> Handle(EditCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = await couponRepository.GetByIdTrackingAsync(request.CouponId);
        if (coupon == null) return OperationResult.NotFound();
        coupon.Edit(request.Code, request.DiscountType, request.DiscountAmount, request.ExpirationDate, request.UsageLimit, couponDomainService);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}