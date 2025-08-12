using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.CommentAgg;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments", "comment");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.ProductId);
        builder.HasIndex(c => c.UserId);
        
        builder.Property(comment => comment.Text)
            .IsRequired()
            .HasMaxLength(500);
    }
}