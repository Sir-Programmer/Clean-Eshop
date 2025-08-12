using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities.Banner;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Banners;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.ToTable("Banners");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Url)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(b => b.ImageName)
            .IsRequired()
            .HasMaxLength(100);
    }
}