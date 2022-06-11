using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManager.Domain.Entities;

namespace PermissionManager.Infrastructure.Persistence.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).IsRequired();
        builder.Property(m => m.FirstName).IsRequired();
        builder.Property(m => m.LastName).IsRequired();
        builder.Property(m => m.PermissionTypeId).IsRequired();
        builder.Property(m => m.PermissionDate).IsRequired();
    }
}