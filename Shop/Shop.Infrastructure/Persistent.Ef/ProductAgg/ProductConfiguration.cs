using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "product");
        builder.HasIndex(p => p.Slug).IsUnique();

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(p => p.Slug)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(p => p.Description)
            .IsRequired();

        builder.Property(p => p.ImageName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.OwnsOne(b => b.SeoData, option =>
        {
            option.Property(b => b.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("MetaDescription");

            option.Property(b => b.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("MetaTitle");

            option.Property(b => b.MetaKeyWords)
                .HasMaxLength(500)
                .HasColumnName("MetaKeyWords");

            option.Property(b => b.IndexPage)
                .HasColumnName("IndexPage");

            option.Property(b => b.Canonical)
                .HasMaxLength(500)
                .HasColumnName("Canonical");

            option.Property(b => b.Schema)
                .HasColumnName("Schema");
        });

        builder.OwnsMany(p => p.Images, option =>
        {
            option.ToTable("Images", "product");
            
            option.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(100);
        });

        builder.OwnsMany(p => p.Specifications, option =>
        {
            option.ToTable("Specifications", "product");

            option.Property(s => s.Key)
                .IsRequired()
                .HasMaxLength(100);
            
            
            option.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(200);
        });
    }
}