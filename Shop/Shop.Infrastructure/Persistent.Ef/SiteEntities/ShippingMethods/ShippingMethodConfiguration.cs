using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities.ShippingMethod;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.ShippingMethods;

public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
{
    public void Configure(EntityTypeBuilder<ShippingMethod> builder)
    {
        builder.ToTable("ShippingMethods", "shipping");

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(200);
    }
}