using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "user");
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.PhoneNumber).IsUnique();

        builder.Property(u => u.Name)
            .IsRequired(false)
            .HasMaxLength(200);
        
        builder.Property(u => u.Family)
            .IsRequired(false)
            .HasMaxLength(200);
        
        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);
        
        builder.Property(u => u.Email)
            .IsRequired(false)
            .HasMaxLength(200);
        
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(200);

        builder.OwnsMany(u => u.Addresses, option =>
        {
            option.ToTable("Addresses", "user");
            option.HasIndex(a => a.UserId);
            
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

        builder.OwnsMany(u => u.Roles, option =>
        {
            option.ToTable("Roles", "user");
            option.HasIndex(r => r.UserId);
        });
        
        builder.OwnsMany(u => u.Wallets, option =>
        {
            option.ToTable("Wallets", "user");
            option.HasIndex(w => w.UserId);

            option.Property(w => w.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        });
    }
}