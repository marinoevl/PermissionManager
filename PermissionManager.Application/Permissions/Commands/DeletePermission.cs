using Microsoft.EntityFrameworkCore;
using PermissionManager.Application.Common.Dtos.Permissions;
using PermissionManager.Application.Common.Exceptions;
using PermissionManager.Application.Common.Interfaces.Persistence;
using PermissionManager.Application.Common.Interfaces.Services;

namespace PermissionManager.Application.Permissions.Commands;

public class DeletePermission : IDeletePermission
{
    private readonly IApplicationDbContext _context;
    private readonly IPermissionRepository _permissionRepository;

    public DeletePermission(IApplicationDbContext context, 
        IPermissionRepository permissionRepository)
    {
        _context = context;
        _permissionRepository = permissionRepository;
    }

    public async Task Invoke(DeletePermissionByIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null) throw new NullArgumentException(nameof(DeletePermissionByIdRequest));

        var entityExists = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entityExists == null)
            throw new NotFoundException(nameof(DeletePermissionByIdRequest), request.Id.ToString());

        _permissionRepository.Delete(entityExists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}