using PermissionManager.Domain.Entities;

namespace PermissionManager.Application.Common.Interfaces.Persistence;

public interface IPermissionRepository
{
    IQueryable<Permission> GetAll();
    Task<Permission> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task CreateAsync(Permission permission, CancellationToken cancellationToken);
    void Delete(Permission permission);
}