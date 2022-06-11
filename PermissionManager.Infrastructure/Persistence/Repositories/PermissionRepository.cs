using Microsoft.EntityFrameworkCore;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Domain.Entities;

namespace PermissionManager.Infrastructure.Persistence.Repositories;

public class PermissionRepository: IPermissionRepository
{
    private readonly IApplicationDbContext _context;

    public PermissionRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Permission> GetAll()
    {
        return _context.Permissions.AsNoTracking();
    }

    public async Task<Permission> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Permissions.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Permission permission, CancellationToken cancellationToken)
    {
        await _context.Permissions.AddAsync(permission, cancellationToken);
    }
    
    public void Delete(Permission permission)
    {
        _context.Permissions.Remove(permission);
    }
}