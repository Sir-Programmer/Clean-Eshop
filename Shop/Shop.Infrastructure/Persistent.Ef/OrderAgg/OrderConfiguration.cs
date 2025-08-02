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
            option.Property(a => a.Province)
                .IsRequired()
                .HasMaxLength(100);
            
            option.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);
            
            option.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(100);
            
            option.Property(a => a.NationalId)
                .IsRequired()
                .HasMaxLength(10);
            
            option.Property(a => a.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
            
            option.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(10);
            
            option.Property(a => a.PostalAddress)
                .IsRequired()
                .HasMaxLength(500);
        });

        builder.OwnsOne(o => o.Discount);

        builder.OwnsOne(o => o.ShippingMethod, option =>
        {
            option.Property(s => s.ShippingType)
                .HasMaxLength(100);
        });
    }
}