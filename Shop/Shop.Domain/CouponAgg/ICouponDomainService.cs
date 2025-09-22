namespace Shop.Domain.CouponAgg;

public interface ICouponDomainService
{
    public bool IsCodeExist(string code);
}