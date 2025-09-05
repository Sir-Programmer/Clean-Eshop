using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "user");
        builder.HasKey(u => u.Id);
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
            option.HasKey(a => a.Id);
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

        builder.OwnsMany(u => u.Tokens, option =>
        {
            option.ToTable("Tokens", "user");
            option.HasKey(k => k.Id);
            
            option.Property(b => b.TokenHash)
                .IsRequired()
                .HasMaxLength(250);

            option.Property(b => b.RefreshTokenHash)
                .IsRequired()
                .HasMaxLength(250);

            option.Property(b => b.Device)
                .IsRequired()
                .HasMaxLength(200);
        });

        builder.OwnsMany(u => u.Roles, option =>
        {
            option.ToTable("Roles", "user");
            option.HasKey(r => r.Id);
            option.HasIndex(r => r.UserId);
        });
        
        builder.OwnsMany(u => u.Wallets, option =>
        {
            option.ToTable("Wallets", "user");
            option.HasKey(w => w.Id);
            option.HasIndex(w => w.UserId);

            option.Property(w => w.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        });
    }
}