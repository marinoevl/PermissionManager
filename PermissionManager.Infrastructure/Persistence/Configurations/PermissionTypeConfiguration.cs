using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManager.Domain.Entities;

namespace PermissionManager.Infrastructure.Persistence.Configurations;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> builder)
    {
        builder.ToTable("PermissionType");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).IsRequired();
        builder.Property(m => m.Description).IsRequired();
    }
}