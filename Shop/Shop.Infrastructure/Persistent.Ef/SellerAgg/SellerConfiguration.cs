using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers", "seller");
        builder.HasIndex(s => s.NationalId).IsUnique();

        builder.Property(s => s.NationalId)
            .IsRequired()
            .HasMaxLength(10);
        
        builder.Property(s => s.ShopName)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsMany(s => s.Inventories, option =>
        {
            option.ToTable("Inventories", "seller");

            option.HasIndex(i => i.ProductId);
            option.HasIndex(i => i.SellerId);
        });
    }
}