using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.Entities;

namespace PermissionManager.Application.Common.Interfaces.Persistence;

public interface IApplicationDbContext
{
    DbSet<Permission> Permissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}