using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg;

public class RoleConfiguration :  IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "role");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsMany(r => r.Permissions, option =>
        {
            option.ToTable("Permissions", "role");
        });
    }
}