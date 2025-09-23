using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CouponAgg;
using Shop.Domain.CouponAgg.Repository;

namespace Shop.Application.Coupons.Create;

public class CreateCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork, ICouponDomainService couponDomainService) : IBaseCommandHandler<CreateCouponCommand>
{
    public async Task<OperationResult> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = new Coupon(request.Code, request.DiscountType, request.DiscountAmount, request.ExpirationDate,
            request.UsageLimit, couponDomainService);
        await couponRepository.AddAsync(coupon);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}