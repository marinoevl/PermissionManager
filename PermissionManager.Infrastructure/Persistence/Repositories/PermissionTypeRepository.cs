using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Domain.Entities;

namespace PermissionManager.Infrastructure.Persistence.Repositories;

public class PermissionTypeRepository: IPermissionTypeRepository
{
    private readonly ApplicationDbContext _context;

    public PermissionTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<PermissionType> GetAll()
    {
        return _context.PermissionTypes;
    }
}