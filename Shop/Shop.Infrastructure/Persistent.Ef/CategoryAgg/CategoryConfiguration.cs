using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CategoryAgg;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "category");
        builder.HasIndex(c => c.Slug).IsUnique();
        
        builder.Property(c => c.Slug)
            .IsRequired()
            .IsUnicode(false);

        builder.Property(c => c.Title)
            .IsRequired();
        
        builder
            .HasMany(b => b.Childs)
            .WithOne()
            .HasForeignKey(b => b.ParentId);
        
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
    }
}