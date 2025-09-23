using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CouponAgg.Repository;

namespace Shop.Application.Coupons.Delete;

public class DeleteCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<DeleteCouponCommand>
{
    public async Task<OperationResult> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = await couponRepository.GetByIdAsync(request.CouponId);
        if (coupon == null) return OperationResult.NotFound();
        couponRepository.Delete(coupon);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}