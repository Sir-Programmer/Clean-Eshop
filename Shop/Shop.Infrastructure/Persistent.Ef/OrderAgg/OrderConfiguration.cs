using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "order");
        builder.HasIndex(o => o.UserId);

        builder.OwnsMany(o => o.Items, option =>
        {
            option.ToTable("Items", "order");
            option.HasIndex(i => i.InventoryId);
            option.HasIndex(i => i.OrderId);
        });

        builder.OwnsOne(o => o.Address, option =>
        {
            option.ToTable("Addresses", "order");
        });

        builder.OwnsOne(o => o.Discount, option =>
        {
            
        });

        builder.OwnsOne(o => o.ShippingMethod, option =>
        {
            
        });
    }
}