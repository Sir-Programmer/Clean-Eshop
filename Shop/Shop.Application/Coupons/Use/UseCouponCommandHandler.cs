using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CouponAgg.Repository;

namespace Shop.Application.Coupons.Use;

public class UseCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<UseCouponCommand>
{
    public async Task<OperationResult> Handle(UseCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = await couponRepository.GetByIdTrackingAsync(request.CouponId);
        if (coupon == null) return OperationResult.NotFound();
        coupon.MarkAsUsed();
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}