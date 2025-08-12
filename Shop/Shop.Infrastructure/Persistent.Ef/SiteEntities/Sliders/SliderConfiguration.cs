using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities.Slider;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Sliders;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.ToTable("Sliders");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(s => s.Url)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(s => s.ImageName)
            .IsRequired()
            .HasMaxLength(100);
    }
}