using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.VerificationAgg;

namespace Shop.Infrastructure.Persistent.Ef.VerificationAgg;

public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.ToTable("Verifications","dbo");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.PhoneNumber);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(11)
            .IsRequired();
        
        builder.Property(x => x.Code)
            .HasMaxLength(6)
            .IsRequired();
    }
}