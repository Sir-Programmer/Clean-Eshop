using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CouponAgg;

namespace Shop.Infrastructure.Persistent.Ef.CouponAgg;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.ToTable("Coupons", "dbo");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Code);
    }
}